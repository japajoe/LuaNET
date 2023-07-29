using System;
using LuaNET;
using LuaNET.Interop;
using LuaNET.Modules;

namespace LuaNETExample
{
    public class TestModule : LuaModule
    {
        public override void Initialize(LuaState L)
        {
            //Registers any method in this class with the LuaExternalMethod attribute so Lua can request a function pointer to C-Sharp methods
            RegisterExternalMethods();

            //This assumes testmodule.lua is in the same directory as the executable
            LuaModuleLoader.RegisterFromFile(L, "testmodule", "testmodule.lua");
        }

        [LuaExternalMethod]
        private static unsafe void TestModuleWriteLine(byte* message)
        {
            //On the lua side we define this method as taking a char pointer
            //Note that a 'char' in C-Sharp is a 16 bit entity and not 8 bit like in C/C++
            //For this reason we use a byte pointer instead
            //Lua owns this pointer (memory) and you should not free it
            string s = new string((sbyte*)message);
            Console.WriteLine(s);
        }
    }
}