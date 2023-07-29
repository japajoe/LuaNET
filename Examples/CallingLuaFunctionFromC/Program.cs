using System;
using System.IO;
using LuaNET;

namespace LuaNETExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "CallingLuaFunctionFromC.lua";

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
                Lua.GetGlobal(state, "DoSomething");
                Lua.PushString(state, "C-Sharp says hi to Lua");
                Lua.PushInteger(state, 10);
                Lua.PCall(state, 2, 0, 0);
                Lua.Close(state);
            }
        }
    }
}