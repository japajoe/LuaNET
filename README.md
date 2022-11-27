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
            string code = "print(\"Hello world\")";

            LuaState state = Lua.NewState();            

            if (state.IsValid)
            {
                Lua.OpenLibs(state);
                Lua.DoString(state, code);
                Lua.Close(state);
            }
        }
    }
}
```

# More Examples
See [Examples](https://github.com/japajoe/LuaJITSharp/tree/main/Examples).