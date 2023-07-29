using System;
using System.Collections.Generic;
using System.IO;
using LuaNET;
using LuaNET.Modules;

namespace LuaNETExample
{
    class Program
    {
        private static List<LuaModule> modules = new List<LuaModule>();
        
        static void Main(string[] args)
        {
            string filepath = "CallingCSharpFunctionFromLua.lua";

            if(!File.Exists(filepath))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            LuaState state = Lua.NewState();            

            if (!state.IsNull)
            {
                Lua.OpenLibs(state);

                modules.Add(new LuaNETModule()); //Needed to obtain function pointers from C-Sharp
                modules.Add(new TestModule());

                for(int i = 0; i < modules.Count; i++)
                    modules[i].Initialize(state);

                Lua.DoFile(state, filepath);                
                Lua.Close(state);
            }
        }
    }
}