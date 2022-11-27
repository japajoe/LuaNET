using System;

namespace LuaJITSharp
{
    public static class LuaHelper
    {
        public static int GetArgumentCount(LuaState L)
        {
            return LuaNative.lua_gettop(L);
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