using System;
using System.IO;
using LuaNET;

namespace LuaNETExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "modules.lua";

            if(!File.Exists(filepath))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            LuaState state = Lua.NewState();            

            if (!state.IsNull)
            {
                Lua.OpenLibs(state);
                HttpClientModule.Register(state);
                Lua.DoFile(state, filepath);                
                Lua.Close(state);
            }
        }
    }
}
