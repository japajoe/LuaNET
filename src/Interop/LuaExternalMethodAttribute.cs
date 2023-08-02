using System;

namespace LuaNET.Interop
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class LuaExternalMethodAttribute : Attribute
    {
        public string Name;

        public LuaExternalMethodAttribute()
        {
            this.Name = string.Empty;
        }

        public LuaExternalMethodAttribute(string name)
        {
            this.Name = name;
        }
    }
}