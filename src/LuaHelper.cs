using System;

namespace LuaNET
{
    public static class LuaHelper
    {
        public static int GetArgumentCount(LuaState L)
        {
            return LuaNative.lua_gettop(L);
        }

        public static bool CheckArgumentCount(LuaState L, int argsMin, int argsMax, out int argsActual)
        {
            argsActual = GetArgumentCount(L);

            if(argsActual < argsMin || argsActual > argsMax)
            {
                if(argsMin == argsMax)
                {
                    string message = "Expected " + argsMin + " argument(s) but got " + argsActual;
                    Console.WriteLine(message);
                }
                else
                {
                    string message  = "Expected at least " + argsMin + " and maximum " + argsMax + " argument(s) but got " + argsActual;
                    Console.WriteLine(message);
                }
                return false;
            }

            return true;
        }        

        public static bool CheckTypes(LuaState L, params LuaType[] types)
        {
            int count = 0;
            int index = 0 - types.Length;

            for (int i = 0; i < types.Length; i++)
            {
                LuaType type = (LuaType)LuaNative.lua_type(L, index + count);
                count++;

                if(type != types[i])
                {
                    Console.WriteLine("Unexpected parameter at index " + count + ". Expected " + types[i] + " but got " + type);
                    return false;
                }
            }

            return true;
        }

        public static byte PopUInt8(LuaState L)
        {            
            byte value = (byte)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);    
            return value;
        }

        public static sbyte PopInt8(LuaState L)
        {
            sbyte value = (sbyte)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);    
            return value;
        }

        public static UInt16 PopUInt16(LuaState L)
        {
            UInt16 value = (UInt16)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);    
            return value;
        }

        public static Int16 PopInt16(LuaState L)
        {
            Int16 value = (Int16)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);    
            return value;
        }

        public static UInt32 PopUInt32(LuaState L)
        {
            UInt32 value = (UInt32)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);    
            return value;
        }

        public static Int32 PopInt32(LuaState L)
        {
            Int32 value = (Int32)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);    
            return value;
        }

        public static UInt64 PopUInt64(LuaState L)
        {
            UInt64 value = (UInt64)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);    
            return value;
        }

        public static Int64 PopInt64(LuaState L)
        {
            Int64 value = (Int64)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);    
            return value;
        }

        public static float PopFloat(LuaState L)
        {
            float value = (float)LuaNative.lua_tonumber(L, -1);
            LuaNative.lua_pop(L, 1);    
            return value;
        }

        public static double PopDouble(LuaState L)
        {
            double value = LuaNative.lua_tonumber(L, -1);
            LuaNative.lua_pop(L, 1);    
            return value;
        }

        public static bool PopBool(LuaState L)
        {
            bool value = LuaNative.lua_toboolean(L, -1) > 0 ? true : false;
            LuaNative.lua_pop(L, 1);
            return value;
        }

        public static string PopString(LuaState L)
        {
            string value = LuaNative.lua_tostring(L, -1);
            LuaNative.lua_pop(L, 1);
            return value;
        }

        public static void PushTable(LuaState L)
        {
            LuaNative.lua_newtable(L);
        }

        public static void PushTableField(LuaState L, string name, string value)
        {
            LuaNative.lua_pushstring(L, name);
            LuaNative.lua_pushstring(L, value);
            LuaNative.lua_settable(L, -3);
        }

        public static void PushTableField(LuaState L, string name, long value)
        {
            LuaNative.lua_pushstring(L, name);
            LuaNative.lua_pushinteger(L, value);
            LuaNative.lua_settable(L, -3);
        }

        public static void PushTableField(LuaState L, string name, double value)
        {
            LuaNative.lua_pushstring(L, name);
            LuaNative.lua_pushnumber(L, value);
            LuaNative.lua_settable(L, -3);
        }

        public static void PushTableField(LuaState L, string name, IntPtr value)
        {
            LuaNative.lua_pushstring(L, name);
            LuaNative.lua_pushlightuserdata(L, value);
            LuaNative.lua_settable(L, -3);
        }

        public static void PopTableField(LuaState L, string name, out string value)
        {
            LuaNative.lua_pushstring(L, name);
            LuaNative.lua_gettable(L, -2);
            value = LuaNative.lua_tostring(L, -1);
            LuaNative.lua_pop(L, 1);
        }

        public static void PopTableField(LuaState L, string name, out long value)
        {
            LuaNative.lua_pushstring(L, name);
            LuaNative.lua_gettable(L, -2);
            value = LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);
        }

        public static void PopTableField(LuaState L, string name, out double value)
        {
            LuaNative.lua_pushstring(L, name);
            LuaNative.lua_gettable(L, -2);
            value = LuaNative.lua_tonumber(L, -1);
            LuaNative.lua_pop(L, 1);
        }

        public static void PopTableField(LuaState L, string name, out IntPtr value)
        {
            LuaNative.lua_pushstring(L, name);
            LuaNative.lua_gettable(L, -2);
            value = LuaNative.lua_touserdata(L, -1);
            LuaNative.lua_pop(L, 1);
        }        

        public static bool TryPopUInt8(LuaState L, out byte value)
        {
            if(LuaNative.lua_isnumber(L, -1) < 1)
            {
                value = default;
                return false;
            }

            value = (byte)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);
            return true;
        }

        public static bool TryPopInt8(LuaState L, out sbyte value)
        {
            if(LuaNative.lua_isnumber(L, -1) < 1)
            {
                value = default;
                return false;
            }

            value = (sbyte)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);            
            return true;
        }

        public static bool TryPopUInt16(LuaState L, out UInt16 value)
        {
            if(LuaNative.lua_isnumber(L, -1) < 1)
            {
                value = default;
                return false;
            }

            value = (UInt16)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);
            return true;
        }

        public static bool TryPopInt16(LuaState L, out Int16 value)
        {
            if(LuaNative.lua_isnumber(L, -1) < 1)
            {
                value = default;
                return false;
            }

            value = (Int16)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);
            return true;
        }

        public static bool TryPopUInt32(LuaState L, out UInt32 value)
        {
            if(LuaNative.lua_isnumber(L, -1) < 1)
            {
                value = default;
                return false;
            }

            value = (UInt32)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);
            return true;
        }

        public static bool TryPopInt32(LuaState L, out Int32 value)
        {
            if(LuaNative.lua_isnumber(L, -1) < 1)
            {
                value = default;
                return false;
            }

            value = (Int32)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);
            return true;
        }

        public static bool TryPopUInt64(LuaState L, out UInt64 value)
        {
            if(LuaNative.lua_isnumber(L, -1) < 1)
            {
                value = default;
                return false;
            }

            value = (UInt64)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);
            return true;
        }

        public static bool TryPopInt64(LuaState L, out Int64 value)
        {
            if(LuaNative.lua_isnumber(L, -1) < 1)
            {
                value = default;
                return false;
            }

            value = (Int64)LuaNative.lua_tointeger(L, -1);
            LuaNative.lua_pop(L, 1);
            return true;
        }

        public static bool TryPopFloat(LuaState L, out float value)
        {
            if(LuaNative.lua_isnumber(L, -1) < 1)
            {
                value = default;
                return false;
            }

            value = (float)LuaNative.lua_tonumber(L, -1);
            LuaNative.lua_pop(L, 1);
            return true;
        }

        public static bool TryPopDouble(LuaState L, out double value)
        {
            if(LuaNative.lua_isnumber(L, -1) < 1)
            {
                value = default;
                return false;
            }

            value = LuaNative.lua_tonumber(L, -1);
            LuaNative.lua_pop(L, 1);
            return true;
        }

        public static bool TryPopBool(LuaState L, out bool value)
        {            
            if(LuaNative.lua_isboolean(L, -1))
            {
                value = default;
                return false;
            }
            
            value = LuaNative.lua_toboolean(L, -1) > 0 ? true : false;
            LuaNative.lua_pop(L, 1);
            return true;
        }

        public static bool TryPopString(LuaState L, out string value)
        {
            if(LuaNative.lua_isstring(L, -1) < 1)
            {
                value = string.Empty;
                return false;
            }            

            value = LuaNative.lua_tostring(L, -1);
            LuaNative.lua_pop(L, 1);
            return true;
        }
    }    
}