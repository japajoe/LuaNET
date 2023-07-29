using System;
using System.IO;
using LuaNET;

namespace LuaNETExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "HelloWorld.lua";

            if(!File.Exists(filepath))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            LuaState state = Lua.NewState();            

            if (state.IsValid)
            {
                Lua.OpenLibs(state);
                Lua.DoFile(state, filepath);                
                Lua.Close(state);
            }
        }
    }
}