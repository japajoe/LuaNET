using System;

namespace LuaJITSharp
{
    public enum LuaType
    {
        None = -1,
        Nil = 0,
        Boolean = 1,
        LightUserData = 2,
        Number = 3,
        String = 4,
        Table = 5,
        Function = 6,
        UserData = 7,
        Thread = 8,
        NumTypes = 9
    }

    public static class Lua
    {
        public static double Version(LuaState L)
        {
            return LuaNative.lua_version_(L);
        }

        public static LuaState NewState()
        {
            return LuaNative.luaL_newstate();
        }

        public static LuaState NewState(LuaAlloc f, UIntPtr ud)
        {
            return LuaNative.lua_newstate(f, ud);
        }

        public static void Close(LuaState L)
        {
            LuaNative.lua_close(L);
        }        

        public static void OpenLibs(LuaState L)
        {
            LuaNative.luaL_openlibs(L);
        }

        public static void OpenBase(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_base);
            LuaNative.lua_call(L,0,0);            
        }

        public static void OpenMath(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_math);
            LuaNative.lua_call(L,0,0);
        }

        public static void OpenString(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_string);
            LuaNative.lua_call(L,0,0);
        }

        public static void OpenTable(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_table);
            LuaNative.lua_call(L,0,0);            
        }

        public static void OpenIO(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_io);
            LuaNative.lua_call(L,0,0);            
        }

        public static void OpenOS(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_os);
            LuaNative.lua_call(L,0,0);            
        }

        public static void OpenPackage(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_package);
            LuaNative.lua_call(L,0,0);            
        }

        public static void OpenDebug(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_debug);
            LuaNative.lua_call(L,0,0);            
        }

        public static void OpenBit(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_bit);
            LuaNative.lua_call(L,0,0);            
        }

        public static void OpenJIT(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_jit);
            LuaNative.lua_call(L,0,0);            
        }

        public static void OpenFFI(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_ffi);
            LuaNative.lua_call(L,0,0);            
        }

        public static void OpenStringBuffer(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_string_buffer);
            LuaNative.lua_call(L,0,0);            
        }

        public static LuaState NewThread(LuaState L)
        {
            return LuaNative.lua_newthread(L);
        }

        public static int GetTop(LuaState L)
        {
            return LuaNative.lua_gettop(L);
        }

        public static void SetTop(LuaState L, int idx)
        {
            LuaNative.lua_settop(L, idx);
        }

        public static void PushValue(LuaState L, int idx)
        {
            LuaNative.lua_pushvalue(L, idx);
        }

        public static void Remove(LuaState L, int idx)
        {
            LuaNative.lua_remove(L, idx);
        }

        public static void Insert(LuaState L, int idx)
        {
            LuaNative.lua_insert(L, idx);
        }

        public static void Replace(LuaState L, int idx)
        {
            LuaNative.lua_replace(L, idx);
        }

        public static int CheckStack(LuaState L, int sz)
        {
            return LuaNative.lua_checkstack(L, sz);
        }

        public static void XMove(LuaState from, LuaState to, int n)
        {
            LuaNative.lua_xmove(from, to, n);
        }

        public static bool IsNumber(LuaState L, int idx)
        {
            return LuaNative.lua_isnumber(L, idx) > 0;
        }

        public static bool IsString(LuaState L, int idx)
        {
            return LuaNative.lua_isstring(L, idx) > 0;
        }

        public static bool IsCFunction(LuaState L, int idx)
        {
            return LuaNative.lua_iscfunction(L, idx) > 0;
        }

        public static bool IsUserData(LuaState L, int idx)
        {
            return LuaNative.lua_isuserdata(L, idx) > 0;
        }

        public static LuaType Type(LuaState L, int idx)
        {
            return (LuaType)LuaNative.lua_type(L, idx);
        }

        public static string TypeName(LuaState L, int tp)
        {
            return LuaNative.lua_typename_(L, tp);
        }

        public static string TypeName(LuaState L, LuaType tp)
        {
            return LuaNative.lua_typename_(L, (int)tp);
        }        

        public static int Equal(LuaState L, int idx1, int idx2)
        {
            return LuaNative.lua_equal(L, idx1, idx2);
        }

        public static int RawEqual(LuaState L, int idx1, int idx2)
        {
            return LuaNative.lua_rawequal(L, idx1, idx2);
        }

        public static int LessThan(LuaState L, int idx1, int idx2)
        {
            return LuaNative.lua_lessthan(L, idx1, idx2);
        }

        public static double ToNumber(LuaState L, int idx)
        {
            return LuaNative.lua_tonumber(L, idx);
        }

        public static Int64 ToInteger(LuaState L, int idx)
        {
            return LuaNative.lua_tointeger(L, idx);
        }

        public static bool ToBoolean(LuaState L, int idx)
        {
            return LuaNative.lua_toboolean(L, idx) > 0 ? true : false;
        }

        public static string ToLString(LuaState L, int idx, ref ulong len)
        {
            return LuaNative.lua_tolstring_(L, idx, ref len);
        }
        public static string ToString(LuaState L, int idx)
        {
            return LuaNative.lua_tostring(L, idx);
        }

        public static UInt64 ObjLen(LuaState L, int idx)
        {
            return LuaNative.lua_objlen(L, idx);
        }

        public static LuaFunction ToCFunction(LuaState L, int idx)
        {
            return LuaNative.lua_tocfunction(L, idx);
        }

        public static UIntPtr ToUserData(LuaState L, int idx)
        {
            return LuaNative.lua_touserdata(L, idx);
        }

        public static LuaState ToThread(LuaState L, int idx)
        {
            return LuaNative.lua_tothread(L, idx);
        }

        public static UIntPtr ToPointer(LuaState L, int idx)
        {
            return LuaNative.lua_topointer(L, idx);
        }

        public static void PushNil(LuaState L)
        {
            LuaNative.lua_pushnil(L);
        }

        public static void PushNumber(LuaState L, double n)
        {
            LuaNative.lua_pushnumber(L, n);
        }

        public static void PushInteger(LuaState L, Int64 n)
        {
            LuaNative.lua_pushinteger(L, n);
        }

        public static void PushLString(LuaState L, string s, UInt64 l)
        {
            LuaNative.lua_pushlstring(L, s, l);
        }

        public static void PushString(LuaState L, string s)
        {
            LuaNative.lua_pushstring(L, s);
        }

        public static void PushCClosure(LuaState L, LuaFunction fn, int n)
        {
            LuaNative.lua_pushcclosure(L, fn, n);
        }

        public static void PushBoolean(LuaState L, bool b)
        {
            LuaNative.lua_pushboolean(L, b ? 1 : 0);
        }

        public static void PushLightUserData(LuaState L, UIntPtr p)
        {
            LuaNative.lua_pushlightuserdata(L, p);
        }

        public static int PushThread(LuaState L)
        {
            return LuaNative.lua_pushthread(L);
        }

        public static void GetTable(LuaState L, int idx)
        {
            LuaNative.lua_gettable(L, idx);
        }

        public static void GetField(LuaState L, int idx, string k)
        {
            LuaNative.lua_getfield(L, idx, k);
        }

        public static LuaType GetFieldWithType(LuaState L, int idx, string k)
        {
            return (LuaType)LuaNative.lua_getfield_with_type(L, idx, k);
        }        

        public static void RawGet(LuaState L, int idx)
        {
            LuaNative.lua_rawget(L, idx);
        }

        public static void RawGetI(LuaState L, int idx, int n)
        {
            LuaNative.lua_rawgeti(L, idx, n);
        }

        public static void CreateTable(LuaState L, int narr, int nrec)
        {
            LuaNative.lua_createtable(L, narr, nrec);
        }

        public static UIntPtr NewUserData(LuaState L, UInt64 sz)
        {
            return LuaNative.lua_newuserdata(L, sz);
        }

        public static int GetMetaTable(LuaState L, int objindex)
        {
            return LuaNative.lua_getmetatable(L, objindex);
        }

        public static void GetFEnv(LuaState L, int idx)
        {
            LuaNative.lua_getfenv(L, idx);
        }

        public static void SetTable(LuaState L, int idx)
        {
            LuaNative.lua_settable(L, idx);
        }

        public static void SetField(LuaState L, int idx, string k)
        {
            LuaNative.lua_setfield(L, idx, k);
        }

        public static void RawSet(LuaState L, int idx)
        {
            LuaNative.lua_rawset(L, idx);
        }

        public static void RawSetI(LuaState L, int idx, int n)
        {
            LuaNative.lua_rawseti(L, idx, n);
        }

        public static int SetMetaTable(LuaState L, int objindex)
        {
            return LuaNative.lua_setmetatable(L, objindex);
        }

        public static int SetFEnv(LuaState L, int idx)
        {
            return LuaNative.lua_setfenv(L, idx);
        }

        public static void Call(LuaState L, int nargs, int nresults)
        {
            LuaNative.lua_call(L, nargs, nresults);
        }

        public static int PCall(LuaState L, int nargs, int nresults, int errfunc)
        {
            return LuaNative.lua_pcall(L, nargs, nresults, errfunc);
        }

        public static int CPCall(LuaState L, LuaFunction func, UIntPtr ud)
        {
            return LuaNative.lua_cpcall(L, func, ud);
        }

        public static int Load(LuaState L, LuaReader reader, UIntPtr dt, string chunkname)
        {
            return LuaNative.lua_load(L, reader, dt, chunkname);
        }

        public static int Dump(LuaState L, LuaWriter writer, UIntPtr data)
        {
            return LuaNative.lua_dump(L, writer, data);
        }

        public static int Yield(LuaState L, int nresults)
        {
            return LuaNative.lua_yield(L, nresults);
        }

        public static int Resume(LuaState L, int narg)
        {
            return LuaNative.lua_resume(L, narg);
        }

        public static int Status(LuaState L)
        {
            return LuaNative.lua_status(L);
        }

        public static int GC(LuaState L, int what, int data)
        {
            return LuaNative.lua_gc(L, what, data);
        }

        public static int Error(LuaState L)
        {
            return LuaNative.lua_error(L);
        }

        public static int Next(LuaState L, int idx)
        {
            return LuaNative.lua_next(L, idx);
        }

        public static void Concat(LuaState L, int n)
        {
            LuaNative.lua_concat(L, n);
        }

        public static LuaAlloc GetAllocF(LuaState L, ref UIntPtr ud)
        {
            return LuaNative.lua_getallocf(L, ref ud);
        }

        public static void SetAllocF(LuaState L, LuaAlloc f, UIntPtr ud)
        {
            LuaNative.lua_setallocf(L, f, ud);
        }

        public static void SetGlobal(LuaState L, string name)
        {
            LuaNative.lua_setglobal(L, name);
        }

        public static void GetGlobal(LuaState L, string name)
        {
            LuaNative.lua_getglobal(L, name);
        }

        public static int LoadFileEx(LuaState L, string filename, string mode)
        {
            return LuaNative.luaL_loadfilex(L, filename, mode);
        }

        public static int LoadBufferEx(LuaState L, string buffer, ulong size, string name, string mode)
        {
            return LuaNative.luaL_loadbufferx(L, buffer, size, name, mode);
        }

        public static int LoadString(LuaState L, string s)
        {
            return LuaNative.luaL_loadstring(L, s);
        }

        public static void Register(LuaState L, string n, LuaFunction f)
        {
            LuaNative.lua_register(L, n, f);
        }

        public static void Pop(LuaState L, int n)
        {
            LuaNative.lua_pop(L, n);
        }

        public static void NewTable(LuaState L)
        {
            LuaNative.lua_newtable(L);
        }

        public static void PushCFunction(LuaState L, LuaFunction f)
        {
            LuaNative.lua_pushcfunction(L, f);
        }

        public static bool IsFunction(LuaState L, int n)
        {
            return LuaNative.lua_isfunction(L, n);
        }

        public static bool IsTable(LuaState L, int n)
        {
            return LuaNative.lua_istable(L, n);
        }

        public static bool IsLightUserData(LuaState L, int n)
        {
            return LuaNative.lua_islightuserdata(L, n);
        }

        public static bool IsNil(LuaState L, int n)
        {
            return LuaNative.lua_isnil(L, n);
        }

        public static bool IsBoolean(LuaState L, int n)
        {
            return LuaNative.lua_isboolean(L, n);
        }

        public static bool IsThread(LuaState L, int n)
        {
            return LuaNative.lua_isthread(L, n);
        }

        public static bool IsNone(LuaState L, int n)
        {
            return LuaNative.lua_isnone(L, n);
        }

        public static bool IsNoneOrNill(LuaState L, int n)
        {
            return LuaNative.lua_isnoneornil(L, n);
        }

        public static int LoadFile(LuaState L, string filename)
        {
            return LuaNative.luaL_loadfile(L, filename);
        }

        public static int DoFile(LuaState L, string filename)
        {
            return LuaNative.luaL_dofile(L, filename);
        }

        public static int DoString(LuaState L, string s)
        {
            return LuaNative.luaL_dostring(L, s);
        }

        public static void RequireF(LuaState L, string modname, LuaFunction openf, int glb)
        {
            LuaNative.luaL_requiref(L, modname, openf, glb);
        }

        public static int GetSubTable(LuaState L, int i, string name)
        {
            return LuaNative.luaL_getsubtable(L, i, name);
        }

        public static int AbsIndex(LuaState L, int i)
        {
            return LuaNative.lua_absindex(L, i);
        }
    }
}