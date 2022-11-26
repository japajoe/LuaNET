# LuaJITSharp
This is a modified fork of https://github.com/tilkinsc/Lua.NET but only with support for LuaJIT. For interaction with LuaJIT you use the Lua class rather than calling the native functions directly. Some convenience types were added to make the experience a little more c-sharpy. Not all LuaJIT library calls are implemented yet but if you are missing something please open an issue.

# Example
```csharp
using System;
using System.IO;
using LuaJITSharp;

namespace LuaJITExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "test.lua";

            if(!File.Exists(filepath))
            {
                Console.WriteLine("File doesn't exist");
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
```