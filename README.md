# LuaNET
A modified fork of https://github.com/tilkinsc/Lua.NET but only with support for LuaJIT. This library uses a more C-Sharp styled API, with built-in functionality to load modules and call C-Sharp methods directly by function pointer.

# Installation
The easiest way to install is with NuGet
```
dotnet add package JAJ.Packages.LuaNET --version 1.0.0
```

# Basic Example
The basic example just prints 'Hello world' to the console.
```csharp
using System;
using System.IO;
using LuaNET;

namespace LuaNETExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "print(\"Hello world\")";

            LuaState state = Lua.NewState();            

            if (!state.IsNull)
            {
                Lua.OpenLibs(state);
                Lua.DoString(state, code);
                Lua.Close(state);
            }
        }
    }
}
```

# Advanced Example
The advanced example creates a Lua module that can call C# methods and prints the output to the console. This is not the typical way of doing interop, but it illustrates the power and flexibility of LuaJIT. First create a file and call it example.lua and paste in the following code:
```lua
local test = require('test')

local result = test.addNumbers(10, 20)

test.writeLine('result: ' .. result)
```

Next create a new file and call it test.lua. Paste in the following code:
```lua
local ffi = require ('ffi')
local luanet = require('luanet')

--You can name this variable however you like
local csharp = {}
csharp.WriteLine = luanet.findMethod('WriteLine', 'void (__cdecl*)(char*)')
csharp.AddNumbers = luanet.findMethod('AddNumbers', 'int (__cdecl*)(int,int)')

local test = {}

function test.writeLine(message)
    --If user passes in a number, converts it to a string
    if type(message) == 'number' then
        message = tostring(message)
    end

    --Interop does not allow to pass Lua strings directly so they need to be converted to a C-type
    --Allocate enough memory for the string + null terminator
    local c_message = ffi.new('char[?]', #message + 1)

    --Copy the Lua string to the allocated memory
    ffi.copy(c_message, message)

    --Call the C# method
    csharp.WriteLine(c_message)
end

function test.addNumbers(a, b)
    local c_a = ffi.cast('int', a)
    local c_b = ffi.cast('int', b)
    local result = csharp.AddNumbers(c_a, c_b)
    return tonumber(result)
end

return test
```

Finally create a file and call it Program.cs and add following code to it:
```csharp
using System;
using LuaNET;
using LuaNET.Interop;
using LuaNET.Modules;

namespace LuaNETExample
{
    class Program
    {
        static void Main(string[] args)
        {
            LuaNETModule luanetModule = new LuaNETModule();
            TestModule testModule = new TestModule();

            LuaState state = Lua.NewState();            

            if (!state.IsNull)
            {
                Lua.OpenLibs(state);

                //LuaNetModule is used to find C# methods and TestModule requires it
                //Loading order of modules is important in this case
                luanetModule.Initialize(state);
                testModule.Initialize(state);

                //Note that this file path assumes that example.lua is in the same directory as the executable
                Lua.DoFile(state, "example.lua");
                Lua.Close(state);
            }
        }
    }
    
    public class TestModule : LuaModule
    {
        public override void Initialize(LuaState L)
        {
            //Register the marked methods before loading the module
            RegisterExternalMethods();

            //Note that this file path assumes that test.lua is in the same directory as the executable
            LuaModuleLoader.RegisterFromFile(L, "test", "test.lua");
        }

        [LuaExternalMethod]
        private static unsafe void WriteLine(byte* text)
        {
            string s = new string((sbyte*)text);
            Console.WriteLine(s);
        }

        [LuaExternalMethod]
        private static unsafe int AddNumbers(int a, int b)
        {
            return a + b;
        }
    }
}
```

# More Examples
See [Examples](https://github.com/japajoe/LuaJITSharp/tree/main/Examples).
