using System;

namespace LuaNET.Interop
{
    public class LuaDelegate
    {
        public Delegate del;
        public IntPtr pointer;

        public LuaDelegate(Delegate del, IntPtr pointer)
        {
            this.del = del;
            this.pointer = pointer;
        }
    }
}