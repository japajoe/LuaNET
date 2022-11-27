using System;

namespace LuaJITSharp
{
    public static class LuaHelper
    {
        public static int GetArgumentCount(LuaState L)
        {
            return Lua.GetTop(L);
        }

        public static bool CheckTypes(LuaState L, params LuaType[] types)
        {
            int count = 0;
            int index = 0 - types.Length;

            for (int i = 0; i < types.Length; i++)
            {                
                LuaType type = Lua.Type(L, index + count);
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
            byte value = (byte)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);    
            return value;
        }

        public static sbyte PopInt8(LuaState L)
        {
            sbyte value = (sbyte)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);    
            return value;
        }

        public static UInt16 PopUInt16(LuaState L)
        {
            UInt16 value = (UInt16)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);    
            return value;
        }

        public static Int16 PopInt16(LuaState L)
        {
            Int16 value = (Int16)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);    
            return value;
        }

        public static UInt32 PopUInt32(LuaState L)
        {
            UInt32 value = (UInt32)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);    
            return value;
        }

        public static Int32 PopInt32(LuaState L)
        {
            Int32 value = (Int32)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);    
            return value;
        }

        public static UInt64 PopUInt64(LuaState L)
        {
            UInt64 value = (UInt64)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);    
            return value;
        }

        public static Int64 PopInt64(LuaState L)
        {
            Int64 value = (Int64)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);    
            return value;
        }

        public static float PopFloat(LuaState L)
        {
            float value = (float)Lua.ToNumber(L, -1);
            Lua.Pop(L, 1);    
            return value;
        }

        public static double PopDouble(LuaState L)
        {
            double value = Lua.ToNumber(L, -1);
            Lua.Pop(L, 1);    
            return value;
        }

        public static bool PopBool(LuaState L)
        {
            bool value = Lua.ToBoolean(L, -1);
            Lua.Pop(L, 1);
            return value;
        }

        public static string PopString(LuaState L)
        {
            string value = Lua.ToString(L, -1);
            Lua.Pop(L, 1);
            return value;
        }

        public static bool TryPopUInt8(LuaState L, out byte value)
        {
            if (!Lua.IsNumber(L, -1))
            {
                value = default;
                return false;
            }

            value = (byte)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);
            return true;
        }

        public static bool TryPopInt8(LuaState L, out sbyte value)
        {
            if (!Lua.IsNumber(L, -1))
            {
                value = default;
                return false;
            }

            value = (sbyte)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);
            return true;
        }

        public static bool TryPopUInt16(LuaState L, out UInt16 value)
        {
            if (!Lua.IsNumber(L, -1))
            {
                value = default;
                return false;
            }

            value = (UInt16)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);
            return true;
        }

        public static bool TryPopInt16(LuaState L, out Int16 value)
        {
            if (!Lua.IsNumber(L, -1))
            {
                value = default;
                return false;
            }

            value = (Int16)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);
            return true;
        }

        public static bool TryPopUInt32(LuaState L, out UInt32 value)
        {
            if (!Lua.IsNumber(L, -1))
            {
                value = default;
                return false;
            }

            value = (UInt32)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);
            return true;
        }

        public static bool TryPopInt32(LuaState L, out Int32 value)
        {
            if (!Lua.IsNumber(L, -1))
            {
                value = default;
                return false;
            }

            value = (Int32)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);
            return true;
        }

        public static bool TryPopUInt64(LuaState L, out UInt64 value)
        {
            if (!Lua.IsNumber(L, -1))
            {
                value = default;
                return false;
            }

            value = (UInt64)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);
            return true;
        }

        public static bool TryPopInt64(LuaState L, out Int64 value)
        {
            if (!Lua.IsNumber(L, -1))
            {
                value = default;
                return false;
            }

            value = (Int64)Lua.ToInteger(L, -1);
            Lua.Pop(L, 1);
            return true;
        }

        public static bool TryPopFloat(LuaState L, out float value)
        {
            if (!Lua.IsNumber(L, -1))
            {
                value = default;
                return false;
            }

            value = (float)Lua.ToNumber(L, -1);
            Lua.Pop(L, 1);
            return true;
        }

        public static bool TryPopDouble(LuaState L, out double value)
        {
            if (!Lua.IsNumber(L, -1))
            {
                value = default;
                return false;
            }

            value = Lua.ToNumber(L, -1);
            Lua.Pop(L, 1);
            return true;
        }

        public static bool TryPopBool(LuaState L, out bool value)
        {
            if (!Lua.IsBoolean(L, 1))
            {
                value = default;
                return false;
            }
            
            value = Lua.ToBoolean(L, -1);
            Lua.Pop(L, 1);
            return true;
        }

        public static bool TryPopString(LuaState L, out string value)
        {
            if (!Lua.IsString(L, -1))
            {
                value = string.Empty;
                return false;
            }

            value = Lua.ToString(L, -1);
            Lua.Pop(L, 1);
            return true;
        }
    }    
}