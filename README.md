# LuaNET
A modified fork of https://github.com/tilkinsc/Lua.NET but only with support for LuaJIT. This library uses a more C-Sharp styled API, with built-in functionality to load modules and call C-Sharp methods directly by function pointer.

# Example
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

# More Examples
See [Examples](https://github.com/japajoe/LuaJITSharp/tree/main/Examples).
