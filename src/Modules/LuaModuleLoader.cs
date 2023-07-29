using System;
using System.Collections.Generic;

namespace LuaNET.Modules
{
    public static class LuaModuleLoader
    {
        private static Dictionary<string, string> modules = new Dictionary<string, string>();
        private static LuaFunction openf = OpenF;

        //Code modified from https://leiradel.github.io/2020/03/01/Embedding-Lua-Modules.html
        private static int OpenF(LuaState L) 
        {
            /* Get the module name as passed to luaL_requiref. */
            string name = Lua.ToString(L, 1);

            int res;

            /*
            Check if we know the module. We can use this function to load many
            different Lua modules uniquely identified by modname.
            */

            if(modules.ContainsKey(name))
            {
                /*
                Parses the Lua source code and leaves the compiled function on the top
                of the stack if there are no errors.
                */
                res = Lua.LoadBufferEx(L, modules[name], (ulong)modules[name].Length, name, "t");
            }
            else 
            {
                /* Unknown module. */
                return Lua.Error(L);
            }

            /* Check if the call to luaL_loadbufferx was successful. */
            if (res != LuaNative.LUA_OK) {
                return Lua.Error(L);
            }

            /*
            Runs the Lua code and returns whatever it returns as the result of OpenF,
            which will be used as the value of the module.
            */
            Lua.Call(L, 0, 1);
            return 1;
        }

        public static bool RegisterFromFile(LuaState L, string name, string filepath)
        {
            if(!System.IO.File.Exists(filepath))
            {
                Console.WriteLine("Could not register module because the file was not found: " + filepath);
                return false;
            }

            string code = System.IO.File.ReadAllText(filepath);

            return RegisterFromString(L, name, code);
        }        

        public static bool RegisterFromString(LuaState L, string name, string code)
        {
            if(modules.ContainsKey(name))
            {
                Console.WriteLine("A module with this name already exists: " + name);
                return false;
            }

            modules.Add(name, code);
            Lua.RequireF(L, name, openf, 0);
            return true;
        }
    }
}
