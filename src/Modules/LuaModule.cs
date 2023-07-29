using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using LuaNET.Interop;

namespace LuaNET.Modules
{
    public class LuaModule
    {
        protected static Dictionary<string,LuaDelegate> delegates = new Dictionary<string, LuaDelegate>();
        protected static List<LuaFunction> luaFunctions = new List<LuaFunction>();
        
        public virtual void Initialize(LuaState L)
        {
        }

        protected void RegisterExternalMethods()
        {
            Type type = this.GetType();

            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            for(int i = 0; i < methods.Length; i++)
            {
                if (methods[i].GetCustomAttributes(typeof(LuaExternalMethodAttribute), false).Length > 0)
                {
                    var methodInfo = methods[i];
                    var delegateType = Expression.GetDelegateType(methodInfo.GetParameters().Select(p => p.ParameterType).Concat(new[] { methodInfo.ReturnType }).ToArray());
                    var methodDelegate = Delegate.CreateDelegate(delegateType, null, methodInfo);
                    RegisterFunctionPointer(methodInfo.Name, methodDelegate);
                }
            }
        }

        protected void RegisterMethod(LuaState L, string name, LuaFunction method)
        {
            var del = Delegate.CreateDelegate(typeof(LuaFunction), method.Target, method.Method) as LuaFunction;
            luaFunctions.Add(method);
            Lua.Register(L, name, method);
        }

        protected void RegisterFunctionPointer<TDelegate>(string name, TDelegate callback) where TDelegate : Delegate
        {
            var del = Delegate.CreateDelegate(typeof(TDelegate), callback.Target, callback.Method) as TDelegate;
            if (del != null)
            {
                LuaDelegate info = new LuaDelegate(del, Marshal.GetFunctionPointerForDelegate<TDelegate>(del));
                delegates.Add(name, info);
            }
        }

        protected void RegisterFunctionPointer(string name, Delegate callback)
        {
            LuaDelegate info = new LuaDelegate(callback, Marshal.GetFunctionPointerForDelegate(callback));
            delegates.Add(name, info);
        }
    }
}