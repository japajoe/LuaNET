using System;
using System.IO;
using LuaJITSharp;

namespace LuaJITExample
{
    class Program
    {
        private static LuaFunction addNumbers;

        static void Main(string[] args)
        {
            addNumbers = AddNumbers;

            string filepath = "CallingCFunctionFromLua.lua";

            if(!File.Exists(filepath))
            {
                Console.WriteLine("File does not exist");
                return;
            }

            LuaState state = Lua.NewState();            

            if (state.IsValid)
            {
                Lua.Register(state, "AddNumbers", addNumbers);
                Lua.OpenLibs(state);
                Lua.DoFile(state, filepath);                
                Lua.Close(state);
            }
        }

        static int AddNumbers(LuaState state)
        {
            if(LuaHelper.GetArgumentCount(state) != 2)
                return -1;

            if(!LuaHelper.CheckTypes(state, LuaType.Number, LuaType.Number))
                return -1;

            double x = LuaHelper.PopDouble(state);
            double y = LuaHelper.PopDouble(state);
            double result = x + y;
            Lua.PushNumber(state, result);
            return 1;
        }
    }
}