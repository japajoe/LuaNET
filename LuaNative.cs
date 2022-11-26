using System;
using System.Runtime.InteropServices;

using voidp = System.UIntPtr;
using charp = System.IntPtr;
using size_t = System.UInt64;
using lua_Number = System.Double;
using lua_Integer = System.Int64;

namespace LuaJITSharp
{
    public delegate int LuaFunction(LuaState L);
    public delegate charp LuaReader(LuaState L, voidp ud, ref size_t sz);
    public delegate int LuaWriter(LuaState L, voidp p, size_t sz, voidp ud);
    public delegate voidp LuaAlloc(voidp ud, voidp ptr, size_t osize, size_t nsize);
    public delegate void LuaHook(LuaState L, LuaDebug ar);

    [StructLayout(LayoutKind.Sequential)]
    public struct LuaState
    {
        public UIntPtr pointer;

        public bool IsValid
        {
            get
            {
                return pointer != UIntPtr.Zero;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct LuaDebug
    {
        public int _event;
        public string name;
        public string namewhat;
        public string what;
        public string source;
        public int currentline;
        public int nups;
        public int linedefined;
        public int lastlinedefined;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = LuaNative.LUA_IDSIZE)]
        public sbyte[] short_src;
        public int i_ci;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct LuaLReg
    {
        string name;
        LuaFunction func;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct LuaLBuffer
    {
        public charp p;
        public int lvl;
        public LuaState L;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = LuaNative.LUAL_BUFFERSIZE)]
        public sbyte[] buffer;
    }        

    public static class LuaNative
    {
        private const string LIBRARY_NAME = "lua51";
        private const CallingConvention Convention = CallingConvention.Cdecl;

        public const string LUAJIT_VERSION = "LuaJIT 2.1.0-beta3";
        public const int LUAJIT_VERSION_NUM = 20100;
        public const string LUAJIT_VERSION_SYM = "luaJIT_version_2_1_0_beta3";
        public const string LUAJIT_COPYRIGHT = "Copyright (C) 2005-2022 Mike Pall";
        public const string LUAJIT_URL = "https://luajit.org/";

        public const int LUAJIT_MODE_MASK = 0x00FF;

        public const int LUAJIT_MODE_ENGINE = 0;
        public const int LUAJIT_MODE_DEBUG = 1;
        public const int LUAJIT_MODE_FUNC = 2;
        public const int LUAJIT_MODE_ALLFUNC = 3;
        public const int LUAJIT_MODE_ALLSUBFUNC = 4;
        public const int LUAJIT_MODE_TRACE = 5;
        public const int LUAJIT_MODE_WRAPCFUNC = 0x10;
        public const int LUAJIT_MODE_MODE_MAX = 0x11;

        public const int LUAJIT_MODE_OFF = 0x0000;
        public const int LUAJIT_MODE_ON = 0x0100;
        public const int LUAJIT_MODE_FLUSH = 0x0200;

        public delegate void luaJIT_profile_callback(voidp data, LuaState L, int samples, int vmstate);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaJIT_profile_start(LuaState L, string mode, luaJIT_profile_callback cb, voidp data);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaJIT_profile_stop(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr luaJIT_profile_dumpstack(LuaState L, string fmt, int depth, ref size_t len);
        
        public static string luaJIT_profile_dumpstack_(LuaState L, string fmt, int depth, ref size_t len)
        {
            return PtrToStringAnsi(luaJIT_profile_dumpstack(L, fmt, depth, ref len));
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaJIT_version_2_1_0_beta3();

        public const string LUA_LDIR = "!\\lua\\";
        public const string LUA_CDIR = "!\\";

        public const string LUA_PATH_DEFAULT = ".\\?.lua;" + LUA_LDIR + "?.lua;" + LUA_LDIR + "?\\init.lua;";
        public const string LUA_CPATH_DEFAULT = ".\\?.dll;" + LUA_CDIR + "?.dll;" + LUA_CDIR + "loadall.dll";

        public const string LUA_PATH = "LUA_PATH";
        public const string LUA_CPATH = "LUA_CPATH";
        public const string LUA_INIT = "LUA_INIT";

        public const string LUA_DIRSEP = "\\";
        public const string LUA_PATHSEP = ";";
        public const string LUA_PATH_MARK = "?";
        public const string LUA_EXECDIR = "!";
        public const string LUA_IGMARK = "-";
        public const string LUA_PATH_CONFIG = LUA_DIRSEP + "\n" + LUA_PATHSEP + "\n" + LUA_PATH_MARK + "\n" + LUA_EXECDIR + "\n" + LUA_IGMARK + "\n";

        public static string LUA_QL(string x)
        {
            return "'" + x + "'";
        }

        public const string LUA_QS = "'%s'";

        public const int LUAI_MAXSTACK = 65500;
        public const int LUAI_MAXCSTACK = 8000;
        public const int LUAI_GCPAUSE = 200;
        public const int LUAI_GCMUL = 200;
        public const int LUA_MAXCAPTURES = 32;

        public const int LUA_IDSIZE = 60;

        public const int LUAL_BUFFERSIZE = 512 > 16384 ? 8182 : 512;

        public const string LUA_VERSION = "Lua 5.1";
        public const string LUA_RELEASE = "Lua 5.1.4";
        public const int LUA_VERSION_NUM = 501;
        public const string LUA_COPYRIGHT = "Copyright (C) 1994-2008 Lua.org, PUC-Rio";
        public const string LUA_AUTHORS = "R. Ierusalimschy, L. H. de Figueiredo, W. Celes";

        public const string LUA_SIGNATURE = "\x1bLua";

        public const int LUA_MULTRET = -1;

        public const int LUA_REGISTRYINDEX = (-10000);
        public const int LUA_ENVIRONINDEX = (-10001);
        public const int LUA_GLOBALSINDEX = (-10002);

        public static int lua_upvalueindex(int i)
        {
            return LUA_GLOBALSINDEX - i;
        }

        public const int LUA_OK = 0;
        public const int LUA_YIELD = 1;
        public const int LUA_ERRRUN = 2;
        public const int LUA_ERRSYNTAX = 3;
        public const int LUA_ERRMEM = 4;
        public const int LUA_ERRERR = 5;

        public const int LUA_TNONE = -1;
        public const int LUA_TNIL = 0;
        public const int LUA_TBOOLEAN = 1;
        public const int LUA_TLIGHTUSERDATA = 2;
        public const int LUA_TNUMBER = 3;
        public const int LUA_TSTRING = 4;
        public const int LUA_TTABLE = 5;
        public const int LUA_TFUNCTION = 6;
        public const int LUA_TUSERDATA = 7;
        public const int LUA_TTHREAD = 8;

        public const int LUA_MINSTACK = 20;

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern LuaState lua_newstate(LuaAlloc f, voidp ud);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_close(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern LuaState lua_newthread(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern LuaFunction lua_atpanic(LuaState L, LuaFunction panicf);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_gettop(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_settop(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_pushvalue(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_remove(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_insert(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_replace(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_checkstack(LuaState L, int sz);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_xmove(LuaState from, LuaState to, int n);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_isnumber(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_isstring(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_iscfunction(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_isuserdata(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_type(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr lua_typename(LuaState L, int tp);
        
        public static string lua_typename_(LuaState L, int tp)
        {
            return PtrToStringAnsi(lua_typename(L, tp));
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_equal(LuaState L, int idx1, int idx2);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_rawequal(LuaState L, int idx1, int idx2);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_lessthan(LuaState L, int idx1, int idx2);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern lua_Number lua_tonumber(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern lua_Integer lua_tointeger(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_toboolean(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr lua_tolstring(LuaState L, int idx, ref ulong len);
        
        public static string lua_tolstring_(LuaState L, int idx, ref ulong len)
        {
            return PtrToStringAnsi(lua_tolstring(L, idx, ref len));
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern ulong lua_objlen(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern LuaFunction lua_tocfunction(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern voidp lua_touserdata(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern LuaState lua_tothread(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern voidp lua_topointer(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_pushnil(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_pushnumber(LuaState L, lua_Number n);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_pushinteger(LuaState L, lua_Integer n);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_pushlstring(LuaState L, string s, size_t len);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_pushstring(LuaState L, string s);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_pushcclosure(LuaState L, LuaFunction fn, int n);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_pushboolean(LuaState L, int b);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_pushlightuserdata(LuaState L, voidp p);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_pushthread(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_gettable(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_getfield(LuaState L, int idx, string k);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_rawget(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_rawgeti(LuaState L, int idx, int n);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_createtable(LuaState L, int narr, int nrec);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern voidp lua_newuserdata(LuaState L, ulong sz);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_getmetatable(LuaState L, int objindex);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_getfenv(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_settable(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_setfield(LuaState L, int idx, string k);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_rawset(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_rawseti(LuaState L, int idx, int n);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_setmetatable(LuaState L, int objindex);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_setfenv(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_call(LuaState L, int nargs, int nresults);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_pcall(LuaState L, int nargs, int nresults, int errfunc);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_cpcall(LuaState L, LuaFunction func, voidp ud);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_load(LuaState L, LuaReader reader, voidp dt, string chunkname);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_dump(LuaState L, LuaWriter writer, voidp data);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_yield(LuaState L, int nresults);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_resume(LuaState L, int narg);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_status(LuaState L);

        public const int LUA_GCSTOP = 0;
        public const int LUA_GCRESTART = 1;
        public const int LUA_GCCOLLECT = 2;
        public const int LUA_GCCOUNT = 3;
        public const int LUA_GCCOUNTB = 4;
        public const int LUA_GCSTEP = 5;
        public const int LUA_GCSETPAUSE = 6;
        public const int LUA_GCSETSTEPMUL = 7;
        public const int LUA_GCISRUNNING = 9;

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_gc(LuaState L, int what, int data);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_error(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_next(LuaState L, int idx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_concat(LuaState L, int n);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern LuaAlloc lua_getallocf(LuaState L, ref voidp ud);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_setallocf(LuaState L, LuaAlloc f, voidp ud);

        public static void lua_pop(LuaState L, int n)
        {
            lua_settop(L, -(n) - 1);
        }

        public static void lua_newtable(LuaState L)
        {
            lua_createtable(L, 0, 0);
        }

        public static void lua_register(LuaState L, string n, LuaFunction f)
        {
            lua_pushcfunction(L, f);
            lua_setglobal(L, n);
        }

        public static void lua_pushcfunction(LuaState L, LuaFunction f)
        {
            lua_pushcclosure(L, f, 0);
        }

        public static ulong lua_strlen(LuaState L, int i)
        {
            return lua_objlen(L, i);
        }

        public static bool lua_isfunction(LuaState L, int n)
        {
            return (lua_type(L, n) == LUA_TFUNCTION) ? true : false;
        }

        public static bool lua_istable(LuaState L, int n)
        {
            return (lua_type(L, n) == LUA_TTABLE) ? true : false;
        }

        public static bool lua_islightuserdata(LuaState L, int n)
        {
            return (lua_type(L, n) == LUA_TLIGHTUSERDATA) ? true : false;
        }

        public static bool lua_isnil(LuaState L, int n)
        {
            return (lua_type(L, n) == LUA_TNIL) ? true : false;
        }

        public static bool lua_isboolean(LuaState L, int n)
        {
            return (lua_type(L, n) == LUA_TBOOLEAN) ? true : false;
        }

        public static bool lua_isthread(LuaState L, int n)
        {
            return (lua_type(L, n) == LUA_TTHREAD) ? true : false;
        }

        public static bool lua_isnone(LuaState L, int n)
        {
            return (lua_type(L, n) == LUA_TNONE) ? true : false;
        }

        public static bool lua_isnoneornil(LuaState L, int n)
        {
            return (lua_type(L, n) <= 0) ? true : false;
        }

        public static void lua_pushliteral(LuaState L, string s)
        {
            lua_pushlstring(L, s, (size_t)s.Length);
        }

        public static void lua_setglobal(LuaState L, string s)
        {
            lua_setfield(L, LUA_GLOBALSINDEX, s);
        }

        public static void lua_getglobal(LuaState L, string s)
        {
            lua_getfield(L, LUA_GLOBALSINDEX, s);
        }

        public static string lua_tostring(LuaState L, int i)
        {
            ulong len = 0;
            return lua_tolstring_(L, i, ref len);
        }

        public static LuaState lua_open()
        {
            return luaL_newstate();
        }

        public static void lua_getregistry(LuaState L)
        {
            lua_pushvalue(L, LUA_REGISTRYINDEX);
        }

        public static int lua_getgccount(LuaState L)
        {
            return lua_gc(L, LUA_GCCOUNT, 0);
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_setlevel(LuaState from, LuaState to);

        public const int LUA_HOOKCALL = 0;
        public const int LUA_HOOKRET = 1;
        public const int LUA_HOOKLINE = 2;
        public const int LUA_HOOKCOUNT = 3;
        public const int LUA_HOOKTAILRET = 4;

        public const int LUA_MASKCALL = (1 << LUA_HOOKCALL);
        public const int LUA_MASKRET = (1 << LUA_HOOKRET);
        public const int LUA_MASKLINE = (1 << LUA_HOOKLINE);
        public const int LUA_MASKCOUNT = (1 << LUA_HOOKCOUNT);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_getstack(LuaState L, int level, LuaDebug ar);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_getinfo(LuaState L, string what, LuaDebug ar);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr lua_getlocal(LuaState L, LuaDebug ar, int n);
        
        public static string lua_getlocal_(LuaState L, LuaDebug ar, int n)
        {
            return PtrToStringAnsi(lua_getlocal(L, ar, n));
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr lua_setlocal(LuaState L, LuaDebug ar, int n);
        
        public static string lua_setlocal_(LuaState L, LuaDebug ar, int n)
        {
            return PtrToStringAnsi(lua_setlocal(L, ar, n));
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr lua_getupvalue(LuaState L, int funcindex, int n);
        
        public static string lua_getupvalue_(LuaState L, int funcindex, int n)
        {
            return PtrToStringAnsi(lua_getupvalue(L, funcindex, n));
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr lua_setupvalue(LuaState L, int funcindex, int n);
        
        public static string lua_setupvalue_(LuaState L, int funcindex, int n)
        {
            return PtrToStringAnsi(lua_setupvalue(L, funcindex, n));
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_sethook(LuaState L, LuaHook func, int mask, int count);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern LuaHook lua_gethook(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_gethookmask(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_gethookcount(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern voidp lua_upvalueid(LuaState L, int idx, int n);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_upvaluejoin(LuaState L, int idx1, int n1, int idx2, int n2);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_loadx(LuaState L, LuaReader reader, voidp dt, string chunkname, string mode);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr lua_version(LuaState L);
        
        public static unsafe double lua_version_(LuaState L)
        {
            IntPtr mem = lua_version(L);
            if (mem == IntPtr.Zero)
                return 0;

            return *(double*)mem.ToPointer();
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void lua_copy(LuaState L, int fromidx, int toidx);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern lua_Number lua_tonumberx(LuaState L, int idx, ref int isnum);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern lua_Integer lua_tointegerx(LuaState L, int idx, ref int isnum);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int lua_isyieldable(LuaState L);

        public const int LUA_ERRFILE = LUA_ERRERR + 1;

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_openlib(LuaState L, string libname, LuaLReg l, int nup);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_register(LuaState L, string libname, LuaLReg l);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_getmetafield(LuaState L, int obj, string e);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_callmeta(LuaState L, int obj, string e);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_typerror(LuaState L, int narg, string tname);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_argerror(LuaState L, int numarg, string extramsg);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr luaL_checklstring(LuaState L, int numArg, ref size_t l);
        
        public static string luaL_checklstring_(LuaState L, int numArg, ref size_t l)
        {
            return PtrToStringAnsi(luaL_checklstring(L, numArg, ref l));
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr luaL_optlstring(LuaState L, int numArg, string def, ref size_t l);

        public static string luaL_optlstring_(LuaState L, int numArg, string def, ref size_t l)
        {
            return PtrToStringAnsi(luaL_optlstring(L, numArg, def, ref l));
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern lua_Number luaL_checknumber(LuaState L, int numArg);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern lua_Number luaL_optnumber(LuaState L, int nArg, lua_Number def);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern lua_Integer luaL_checkinteger(LuaState L, int numArg);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern lua_Integer luaL_optinteger(LuaState L, int nArg, lua_Integer def);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_checkstack(LuaState L, int sz, string msg);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_checktype(LuaState L, int narg, int t);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_checkany(LuaState L, int narg);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_newmetatable(LuaState L, string tname);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern voidp luaL_checkudata(LuaState L, int ud, string tname);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_where(LuaState L, int lvl);

        // TODO: I dont think params works
        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_error(LuaState L, string fmt, params string[] args);

        // TODO: I dont think string[][] works
        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_checkoption(LuaState L, int narg, string def, string[][] lst);

        public const int LUA_NOREF = -2;
        public const int LUA_REFNIL = -1;

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_ref(LuaState L, int t);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_unref(LuaState L, int t, int _ref);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_loadfile(LuaState L, string filename);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_loadbuffer(LuaState L, string buff, size_t sz, string name);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_loadstring(LuaState L, string s);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern LuaState luaL_newstate();

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr luaL_gsub(LuaState L, string s, string p, string r);
        
        public static string luaL_gsub_(LuaState L, string s, string p, string r)
        {
            return PtrToStringAnsi(luaL_gsub(L, s, p, r));
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern IntPtr luaL_findtable(LuaState L, int idx, string fname, int szhint);
        
        public static string luaL_findtable_(LuaState L, int idx, string fname, int szhint)
        {
            return PtrToStringAnsi(luaL_findtable(L, idx, fname, szhint));
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_fileresult(LuaState L, int stat, string fname);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_execresult(LuaState L, int stat);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_loadfilex(LuaState L, string filename, string mode);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaL_loadbufferx(LuaState L, string buff, size_t sz, string name, string mode);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_traceback(LuaState L, LuaState L1, string msg, int level);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_setfuncs(LuaState L, LuaLReg[] l, int nup);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_pushmodule(LuaState L, string modename, int sizehint);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern voidp luaL_testudata(LuaState L, int ud, string tname);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_setmetatable(LuaState L, string tname);

        public static void luaL_argcheck(LuaState L, bool cond, int numarg, string extramsg)
        {
            if (cond == false)
                luaL_argerror(L, numarg, extramsg);
        }

        public static string luaL_checkstring(LuaState L, int n)
        {
		    size_t temp = 0; // NOP
		    return luaL_checklstring_(L, n, ref temp);            
        }

        public static string luaL_optstring(LuaState L, int n, string d)
        {
		    size_t temp = 0; // NOP
		    return luaL_optlstring_(L, n, d, ref temp);
        }

        public static int luaL_checkint(LuaState L, int n)
        {
            return (int)luaL_checkinteger(L, n);
        }

        public static int luaL_optint(LuaState L, int n, lua_Integer d)
        {
            return (int)luaL_optinteger(L, n, d);
        }

        public static long luaL_checklong(LuaState L, int n)
        {
            return (long)luaL_checkinteger(L, n);
        }

        public static long luaL_optlong(LuaState L, int n, lua_Integer d)
        {
            return (long)luaL_optinteger(L, n, d);
        }

        public static string luaL_typename(LuaState L, int i)
        {
            return lua_typename_(L, lua_type(L, i));
        }

        public static int luaL_dofile(LuaState L, string fn)
        {
            int status = luaL_loadfile(L, fn);
            if (status > 0)
                return status;
            return lua_pcall(L, 0, LUA_MULTRET, 0);
        }

        public static int luaL_dostring(LuaState L, string s)
        {
            int status = luaL_loadstring(L, s);
            if (status > 0)
                return status;
            return lua_pcall(L, 0, LUA_MULTRET, 0);
        }

        public static void luaL_getmetatable(LuaState L, string n)
        {
            lua_getfield(L, LUA_REGISTRYINDEX, n);
        }

        public delegate T LuaLFunction<T>(LuaState L, int n);

        public static T luaL_opt<T>(LuaState L, LuaLFunction<T> f, int n, T d)
        {
            return (lua_isnoneornil(L, n) == true) ? d : f(L, n);
        }

        public static void luaL_newlibtable(LuaState L, LuaLReg[] l)
        {
            lua_createtable(L, 0, l.Length - 1);
        }

        public static void luaL_newlib(LuaState L, LuaLReg[] l)
        {
            luaL_newlibtable(L, l);
            luaL_setfuncs(L, l, 0);
        }

        public static void luaL_addchar(LuaLBuffer B, byte c)
        {
            if (B.p.ToInt64() >= B.buffer.Length + LUAL_BUFFERSIZE)
                luaL_prepbuffer(B);
            Marshal.WriteByte(B.p, c);
            B.p += 1;
        }

        public static void luaL_putchar(LuaLBuffer B, byte c)
        {
            luaL_addchar(B, c);
        }

        public static void luaL_addsize(LuaLBuffer B, int n)
        {
            B.p += n;
        }

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_buffinit(LuaState L, LuaLBuffer B);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern charp luaL_prepbuffer(LuaLBuffer B);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_addlstring(LuaLBuffer B, string s, size_t l);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_addstring(LuaLBuffer B, string s);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_addvalue(LuaLBuffer B);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_pushresult(LuaLBuffer B);

        public const string LUA_FILEHANDLE = "FILE*";

        public const string LUA_COLIBNAME = "coroutine";
        public const string LUA_MATHLIBNAME = "math";
        public const string LUA_STRLIBNAME = "string";
        public const string LUA_TABLIBNAME = "table";
        public const string IOLIBNAME = "io";
        public const string OSLIBNAME = "os";
        public const string LOADLIBNAME = "package";
        public const string DBLIBNAME = "debug";
        public const string BITLIBNAME = "bit";
        public const string JITLIBNAME = "jit";
        public const string FFILIBNAME = "fii";

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_base(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_math(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_string(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_table(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_io(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_os(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_package(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_debug(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_bit(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_jit(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_ffi(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern int luaopen_string_buffer(LuaState L);

        [DllImport(LIBRARY_NAME, CallingConvention = Convention)]
        public static extern void luaL_openlibs(LuaState L);

        public static string PtrToStringAnsi(IntPtr ptr)        
        {
            if (ptr != IntPtr.Zero)
            {
                return Marshal.PtrToStringAnsi(ptr);
            }

            return string.Empty;
        }
    }
}