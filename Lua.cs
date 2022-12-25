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
        public static int AbsIndex(LuaState L, int i)
        {
            return LuaNative.lua_absindex(L, i);
        }

        public static void ArgCheck(LuaState L, bool cond, int numarg, string extramsg)
        {
            LuaNative.luaL_argcheck(L, cond, numarg, extramsg);
        }

        public static int ArgError(LuaState L, int numarg, string extramsg)
        {
            return LuaNative.luaL_argerror(L, numarg, extramsg);
        }

        public static LuaFunction AtPanic(LuaState L, LuaFunction panicf)
        {
            return LuaNative.lua_atpanic(L, panicf);
        }

        public static void Call(LuaState L, int nargs, int nresults)
        {
            LuaNative.lua_call(L, nargs, nresults);
        }

        public static int CallMeta(LuaState L, int obj, string e)
        {
            return LuaNative.luaL_callmeta(L, obj, e);
        }

        public static void CheckAny(LuaState L, int narg)
        {
            LuaNative.luaL_checkany(L, narg);
        }

        public static int CheckInt(LuaState L, int n)
        {
            return LuaNative.luaL_checkint(L, n);
        }

        public static long CheckInteger(LuaState L, int numArg)
        {
            return LuaNative.luaL_checkinteger(L, numArg);
        }

        public static long CheckLong(LuaState L, int n)
        {
            return LuaNative.luaL_checklong(L, n);
        }

        public static string CheckLString(LuaState L, int numArg, ref ulong l)
        {
            return LuaNative.luaL_checklstring_(L, numArg, ref l);
        }

        public static double CheckNumber(LuaState L, int numArg)
        {
            return LuaNative.luaL_checknumber(L, numArg);
        }

        public static int CheckOption(LuaState L, int narg, string def, string[][] lst)
        {
            return LuaNative.luaL_checkoption(L, narg, def, lst);
        }

        public static int CheckStack(LuaState L, int sz)
        {
            return LuaNative.lua_checkstack(L, sz);
        }

        public static string CheckString(LuaState L, int n)
        {
            return LuaNative.luaL_checkstring(L, n);
        }

        public static void CheckType(LuaState L, int narg, int t)
        {
            LuaNative.luaL_checktype(L, narg, t);
        }

        public static IntPtr CheckUData(LuaState L, int ud, string tname)
        {
            return LuaNative.luaL_checkudata(L, ud, tname);
        }

        public static void Close(LuaState L)
        {
            LuaNative.lua_close(L);
        }

        public static void Concat(LuaState L, int n)
        {
            LuaNative.lua_concat(L, n);
        }

        public static void Copy(LuaState L, int fromidx, int toidx)
        {
            LuaNative.lua_copy(L, fromidx, toidx);
        }

        public static int CPCall(LuaState L, LuaFunction func, IntPtr ud)
        {
            return LuaNative.lua_cpcall(L, func, ud);
        }

        public static void CreateTable(LuaState L, int narr, int nrec)
        {
            LuaNative.lua_createtable(L, narr, nrec);
        }

        public static int DoFile(LuaState L, string filename)
        {
            return LuaNative.luaL_dofile(L, filename);
        }

        public static int DoString(LuaState L, string s)
        {
            return LuaNative.luaL_dostring(L, s);
        }

        public static int Dump(LuaState L, LuaWriter writer, IntPtr data)
        {
            return LuaNative.lua_dump(L, writer, data);
        }

        public static int Equal(LuaState L, int idx1, int idx2)
        {
            return LuaNative.lua_equal(L, idx1, idx2);
        }

        public static int Error(LuaState L)
        {
            return LuaNative.lua_error(L);
        }

        public static int ExecResult(LuaState L, int stat)
        {
            return LuaNative.luaL_execresult(L, stat);
        }

        public static int FileResult(LuaState L, int stat, string fname)
        {
            return LuaNative.luaL_fileresult(L, stat, fname);
        }

        public static string FindTable(LuaState L, int idx, string fname, int szhint)
        {
            return LuaNative.luaL_findtable_(L, idx, fname, szhint);
        }

        public static int GC(LuaState L, int what, int data)
        {
            return LuaNative.lua_gc(L, what, data);
        }

        public static LuaAlloc GetAllocF(LuaState L, ref IntPtr ud)
        {
            return LuaNative.lua_getallocf(L, ref ud);
        }

        public static void GetFEnv(LuaState L, int idx)
        {
            LuaNative.lua_getfenv(L, idx);
        }

        public static void GetField(LuaState L, int idx, string k)
        {
            LuaNative.lua_getfield(L, idx, k);
        }

        public static LuaType GetFieldWithType(LuaState L, int idx, string k)
        {
            return (LuaType)LuaNative.lua_getfield_with_type(L, idx, k);
        }

        public static int GetGCCount(LuaState L)
        {
            return LuaNative.lua_getgccount(L);
        }

        public static void GetGlobal(LuaState L, string name)
        {
            LuaNative.lua_getglobal(L, name);
        }

        public static LuaHook GetHook(LuaState L)
        {
            return LuaNative.lua_gethook(L);
        }

        public static int GetHookAccount(LuaState L)
        {
            return LuaNative.lua_gethookcount(L);
        }

        public static int GetHookMask(LuaState L)
        {
            return LuaNative.lua_gethookmask(L);
        }

        public static int GetInfo(LuaState L, string what, LuaDebug ar)
        {
            return LuaNative.lua_getinfo(L, what, ar);
        }

        public static int GetMetaField(LuaState L, int obj, string e)
        {
            return LuaNative.luaL_getmetafield(L, obj, e);
        }

        public static void GetMetaTable(LuaState L, string n)
        {
            LuaNative.luaL_getmetatable(L, n);
        }

        public static int GetMetaTable(LuaState L, int objindex)
        {
            return LuaNative.lua_getmetatable(L, objindex);
        }

        public static string GetLocal(LuaState L, LuaDebug ar, int n)
        {
            return LuaNative.lua_getlocal_(L, ar, n);
        }

        public static void GetRegistry(LuaState L)
        {
            LuaNative.lua_getregistry(L);
        }

        public static int GetStack(LuaState L, int level, LuaDebug ar)
        {
            return LuaNative.lua_getstack(L, level, ar);
        }

        public static int GetSubTable(LuaState L, int i, string name)
        {
            return LuaNative.luaL_getsubtable(L, i, name);
        }

        public static void GetTable(LuaState L, int idx)
        {
            LuaNative.lua_gettable(L, idx);
        }

        public static int GetTop(LuaState L)
        {
            return LuaNative.lua_gettop(L);
        }

        public static string GetUpValue(LuaState L, int funcindex, int n)
        {
            return LuaNative.lua_getupvalue_(L, funcindex, n);
        }

        public static string GSub(LuaState L, string s, string p, string r)
        {
            return LuaNative.luaL_gsub_(L, s, p, r);
        }

        public static void Insert(LuaState L, int idx)
        {
            LuaNative.lua_insert(L, idx);
        }

        public static bool IsBoolean(LuaState L, int n)
        {
            return LuaNative.lua_isboolean(L, n);
        }

        public static bool IsCFunction(LuaState L, int idx)
        {
            return LuaNative.lua_iscfunction(L, idx) > 0;
        }

        public static bool IsFunction(LuaState L, int n)
        {
            return LuaNative.lua_isfunction(L, n);
        }

        public static bool IsLightUserData(LuaState L, int n)
        {
            return LuaNative.lua_islightuserdata(L, n);
        }

        public static bool IsNil(LuaState L, int n)
        {
            return LuaNative.lua_isnil(L, n);
        }

        public static bool IsNone(LuaState L, int n)
        {
            return LuaNative.lua_isnone(L, n);
        }

        public static bool IsNoneOrNill(LuaState L, int n)
        {
            return LuaNative.lua_isnoneornil(L, n);
        }

        public static bool IsNumber(LuaState L, int idx)
        {
            return LuaNative.lua_isnumber(L, idx) > 0;
        }

        public static bool IsString(LuaState L, int idx)
        {
            return LuaNative.lua_isstring(L, idx) > 0;
        }

        public static bool IsTable(LuaState L, int n)
        {
            return LuaNative.lua_istable(L, n);
        }

        public static bool IsThread(LuaState L, int n)
        {
            return LuaNative.lua_isthread(L, n);
        }

        public static bool IsUserData(LuaState L, int idx)
        {
            return LuaNative.lua_isuserdata(L, idx) > 0;
        }

        public static bool IsYieldable(LuaState L)
        {
            return LuaNative.lua_isyieldable(L) > 0;
        }

        public static int LessThan(LuaState L, int idx1, int idx2)
        {
            return LuaNative.lua_lessthan(L, idx1, idx2);
        }

        public static int Load(LuaState L, LuaReader reader, IntPtr dt, string chunkname)
        {
            return LuaNative.lua_load(L, reader, dt, chunkname);
        }

        public static int LoadBuffer(LuaState L, string buff, ulong sz, string name)
        {
            return LuaNative.luaL_loadbuffer(L, buff, sz, name);
        }

        public static int LoadBufferEx(LuaState L, string buffer, ulong size, string name, string mode)
        {
            return LuaNative.luaL_loadbufferx(L, buffer, size, name, mode);
        }

        public static int LoadFile(LuaState L, string filename)
        {
            return LuaNative.luaL_loadfile(L, filename);
        }

        public static int LoadFileEx(LuaState L, string filename, string mode)
        {
            return LuaNative.luaL_loadfilex(L, filename, mode);
        }

        public static int LoadString(LuaState L, string s)
        {
            return LuaNative.luaL_loadstring(L, s);
        }

        public static int LoadX(LuaState L, LuaReader reader, IntPtr dt, string chunkname, string mode)
        {
            return LuaNative.lua_loadx(L, reader, dt, chunkname, mode);
        }

        public static int NewMetaTable(LuaState L, string tname)
        {
            return LuaNative.luaL_newmetatable(L, tname);
        }

        public static LuaState NewState()
        {
            return LuaNative.luaL_newstate();
        }

        public static LuaState NewState(LuaAlloc f, IntPtr ud)
        {
            return LuaNative.lua_newstate(f, ud);
        }

        public static void NewTable(LuaState L)
        {
            LuaNative.lua_newtable(L);
        }

        public static LuaState NewThread(LuaState L)
        {
            return LuaNative.lua_newthread(L);
        }

        public static IntPtr NewUserData(LuaState L, UInt64 sz)
        {
            return LuaNative.lua_newuserdata(L, sz);
        }

        public static int Next(LuaState L, int idx)
        {
            return LuaNative.lua_next(L, idx);
        }

        public static UInt64 ObjLen(LuaState L, int idx)
        {
            return LuaNative.lua_objlen(L, idx);
        }

        public static LuaState Open()
        {
            return LuaNative.lua_open();
        }

        public static void OpenBase(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_base);
            LuaNative.lua_call(L, 0, 0);
        }

        public static void OpenBit(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_bit);
            LuaNative.lua_call(L, 0, 0);
        }

        public static void OpenDebug(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_debug);
            LuaNative.lua_call(L, 0, 0);
        }

        public static void OpenFFI(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_ffi);
            LuaNative.lua_call(L, 0, 0);
        }

        public static void OpenIO(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_io);
            LuaNative.lua_call(L, 0, 0);
        }

        public static void OpenJIT(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_jit);
            LuaNative.lua_call(L, 0, 0);
        }

        public static void OpenLib(LuaState L, string libname, LuaLReg l, int nup)
        {
            LuaNative.luaL_openlib(L, libname, l, nup);
        }

        public static void OpenLibs(LuaState L)
        {
            LuaNative.luaL_openlibs(L);
        }

        public static void OpenMath(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_math);
            LuaNative.lua_call(L, 0, 0);
        }

        public static void OpenOS(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_os);
            LuaNative.lua_call(L, 0, 0);
        }

        public static void OpenPackage(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_package);
            LuaNative.lua_call(L, 0, 0);
        }

        public static void OpenString(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_string);
            LuaNative.lua_call(L, 0, 0);
        }

        public static void OpenStringBuffer(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_string_buffer);
            LuaNative.lua_call(L, 0, 0);
        }

        public static void OpenTable(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_table);
            LuaNative.lua_call(L, 0, 0);
        }

        public static int OptInt(LuaState L, int n, long d)
        {
            return LuaNative.luaL_optint(L, n, d);
        }

        public static long OptInteger(LuaState L, int nArg, long def)
        {
            return LuaNative.luaL_optinteger(L, nArg, def);
        }

        public static long OptLong(LuaState L, int n, long d)
        {
            return LuaNative.luaL_optlong(L, n, d);
        }

        public static string OptLString(LuaState L, int numArg, string def, ref ulong l)
        {
            return LuaNative.luaL_optlstring_(L, numArg, def, ref l);
        }

        public static double OptNumber(LuaState L, int nArg, double def)
        {
            return LuaNative.luaL_optnumber(L, nArg, def);
        }

        public static string OptString(LuaState L, int n, string d)
        {
            return LuaNative.luaL_optstring(L, n, d);
        }

        public static int PCall(LuaState L, int nargs, int nresults, int errfunc)
        {
            return LuaNative.lua_pcall(L, nargs, nresults, errfunc);
        }

        public static void Pop(LuaState L, int n)
        {
            LuaNative.lua_pop(L, n);
        }

        public static string ProfileDumpStack(LuaState L, string fmt, int depth, ref ulong len)
        {
            return LuaNative.luaJIT_profile_dumpstack_(L, fmt, depth, ref len);
        }

        public static void ProfileStart(LuaState L, string mode, LuaJITProfileCallback cb, IntPtr data)
        {
            LuaNative.luaJIT_profile_start(L, mode, cb, data);
        }

        public static void ProfileStop(LuaState L)
        {
            LuaNative.luaJIT_profile_stop(L);
        }

        public static void PushBoolean(LuaState L, bool b)
        {
            LuaNative.lua_pushboolean(L, b ? 1 : 0);
        }

        public static void PushCClosure(LuaState L, LuaFunction fn, int n)
        {
            LuaNative.lua_pushcclosure(L, fn, n);
        }

        public static void PushCFunction(LuaState L, LuaFunction f)
        {
            LuaNative.lua_pushcfunction(L, f);
        }

        public static void PushInteger(LuaState L, Int64 n)
        {
            LuaNative.lua_pushinteger(L, n);
        }

        public static void PushLiteral(LuaState L, string s)
        {
            LuaNative.lua_pushliteral(L, s);
        }

        public static void PushModule(LuaState L, string modename, int sizehint)
        {
            LuaNative.luaL_pushmodule(L, modename, sizehint);
        }

        public static void PushLightUserData(LuaState L, IntPtr p)
        {
            LuaNative.lua_pushlightuserdata(L, p);
        }

        public static void PushLString(LuaState L, string s, UInt64 l)
        {
            LuaNative.lua_pushlstring(L, s, l);
        }

        public static void PushNil(LuaState L)
        {
            LuaNative.lua_pushnil(L);
        }

        public static void PushNumber(LuaState L, double n)
        {
            LuaNative.lua_pushnumber(L, n);
        }

        public static void PushString(LuaState L, string s)
        {
            LuaNative.lua_pushstring(L, s);
        }

        public static int PushThread(LuaState L)
        {
            return LuaNative.lua_pushthread(L);
        }

        public static void PushValue(LuaState L, int idx)
        {
            LuaNative.lua_pushvalue(L, idx);
        }

        public static string QL(string x)
        {
            return LuaNative.LUA_QL(x);
        }

        public static int RawEqual(LuaState L, int idx1, int idx2)
        {
            return LuaNative.lua_rawequal(L, idx1, idx2);
        }

        public static void RawGet(LuaState L, int idx)
        {
            LuaNative.lua_rawget(L, idx);
        }

        public static void RawGetI(LuaState L, int idx, int n)
        {
            LuaNative.lua_rawgeti(L, idx, n);
        }

        public static void RawSet(LuaState L, int idx)
        {
            LuaNative.lua_rawset(L, idx);
        }

        public static void RawSetI(LuaState L, int idx, int n)
        {
            LuaNative.lua_rawseti(L, idx, n);
        }

        public static int Ref(LuaState L, int t)
        {
            return LuaNative.luaL_ref(L, t);
        }

        public static void Register(LuaState L, string libname, LuaLReg l)
        {
            LuaNative.luaL_register(L, libname, l);
        }

        public static void Register(LuaState L, string n, LuaFunction f)
        {
            LuaNative.lua_register(L, n, f);
        }

        public static void Remove(LuaState L, int idx)
        {
            LuaNative.lua_remove(L, idx);
        }

        public static void Replace(LuaState L, int idx)
        {
            LuaNative.lua_replace(L, idx);
        }

        public static void RequireF(LuaState L, string modname, LuaFunction openf, int glb)
        {
            LuaNative.luaL_requiref(L, modname, openf, glb);
        }

        public static int Resume(LuaState L, int narg)
        {
            return LuaNative.lua_resume(L, narg);
        }

        public static void SetAllocF(LuaState L, LuaAlloc f, IntPtr ud)
        {
            LuaNative.lua_setallocf(L, f, ud);
        }

        public static int SetFEnv(LuaState L, int idx)
        {
            return LuaNative.lua_setfenv(L, idx);
        }

        public static void SetField(LuaState L, int idx, string k)
        {
            LuaNative.lua_setfield(L, idx, k);
        }

        public static void SetFuncs(LuaState L, LuaLReg[] l, int nup)
        {
            LuaNative.luaL_setfuncs(L, l, nup);
        }

        public static void SetGlobal(LuaState L, string name)
        {
            LuaNative.lua_setglobal(L, name);
        }

        public static int SetHook(LuaState L, LuaHook func, int mask, int count)
        {
            return LuaNative.lua_sethook(L, func, mask, count);
        }

        public static void SetMetaTable(LuaState L, string tname)
        {
            LuaNative.luaL_setmetatable(L, tname);
        }

        public static int SetMetaTable(LuaState L, int objindex)
        {
            return LuaNative.lua_setmetatable(L, objindex);
        }

        public static void SetLevel(LuaState from, LuaState to)
        {
            LuaNative.lua_setlevel(from, to);
        }

        public static string SetLocal(LuaState L, LuaDebug ar, int n)
        {
            return LuaNative.lua_setlocal_(L, ar, n);
        }

        public static void SetTable(LuaState L, int idx)
        {
            LuaNative.lua_settable(L, idx);
        }

        public static void SetTop(LuaState L, int idx)
        {
            LuaNative.lua_settop(L, idx);
        }

        public static string SetUpValue(LuaState L, int funcindex, int n)
        {
            return LuaNative.lua_setupvalue_(L, funcindex, n);
        }

        public static int Status(LuaState L)
        {
            return LuaNative.lua_status(L);
        }

        public static ulong StrLen(LuaState L, int i)
        {
            return LuaNative.lua_strlen(L, i);
        }

        public static IntPtr TestUData(LuaState L, int ud, string tname)
        {
            return LuaNative.luaL_testudata(L, ud, tname);
        }

        public static bool ToBoolean(LuaState L, int idx)
        {
            return LuaNative.lua_toboolean(L, idx) > 0 ? true : false;
        }

        public static LuaFunction ToCFunction(LuaState L, int idx)
        {
            return LuaNative.lua_tocfunction(L, idx);
        }

        public static Int64 ToInteger(LuaState L, int idx)
        {
            return LuaNative.lua_tointeger(L, idx);
        }

        public static long ToIntegerX(LuaState L, int idx, ref int isnum)
        {
            return LuaNative.lua_tointegerx(L, idx, ref isnum);
        }

        public static string ToLString(LuaState L, int idx, ref ulong len)
        {
            return LuaNative.lua_tolstring_(L, idx, ref len);
        }

        public static double ToNumber(LuaState L, int idx)
        {
            return LuaNative.lua_tonumber(L, idx);
        }

        public static double ToNumberX(LuaState L, int idx, ref int isnum)
        {
            return LuaNative.lua_tonumberx(L, idx, ref isnum);
        }

        public static IntPtr ToPointer(LuaState L, int idx)
        {
            return LuaNative.lua_topointer(L, idx);
        }

        public static string ToString(LuaState L, int idx)
        {
            return LuaNative.lua_tostring(L, idx);
        }

        public static LuaState ToThread(LuaState L, int idx)
        {
            return LuaNative.lua_tothread(L, idx);
        }

        public static IntPtr ToUserData(LuaState L, int idx)
        {
            return LuaNative.lua_touserdata(L, idx);
        }

        public static void TraceBack(LuaState L, LuaState L1, string msg, int level)
        {
            LuaNative.luaL_traceback(L, L1, msg, level);
        }

        public static LuaType Type(LuaState L, int idx)
        {
            return (LuaType)LuaNative.lua_type(L, idx);
        }

        public static int TypeError(LuaState L, int narg, string tname)
        {
            return LuaNative.luaL_typerror(L, narg, tname);
        }

        public static string TypeName(LuaState L, int tp)
        {
            return LuaNative.lua_typename_(L, tp);
        }

        public static string TypeName(LuaState L, LuaType tp)
        {
            return LuaNative.lua_typename_(L, (int)tp);
        }

        public static void UnRef(LuaState L, int t, int _ref)
        {
            LuaNative.luaL_unref(L, t, _ref);
        }

        public static IntPtr UpValueId(LuaState L, int idx, int n)
        {
            return LuaNative.lua_upvalueid(L, idx, n);
        }

        public static int UpValueIndex(int i)
        {
            return LuaNative.lua_upvalueindex(i);
        }

        public static void UpValueJoin(LuaState L, int idx1, int n1, int idx2, int n2)
        {
            LuaNative.lua_upvaluejoin(L, idx1, n1, idx2, n2);
        }

        public static double Version(LuaState L)
        {
            return LuaNative.lua_version_(L);
        }

        public static void Where(LuaState L, int lvl)
        {
            LuaNative.luaL_where(L, lvl);
        }

        public static void XMove(LuaState from, LuaState to, int n)
        {
            LuaNative.lua_xmove(from, to, n);
        }

        public static int Yield(LuaState L, int nresults)
        {
            return LuaNative.lua_yield(L, nresults);
        }
    }
}