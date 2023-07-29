using System;

namespace LuaNET
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

    public enum LuaGCParam : int
    {
        Stop = 0,
        Restart = 1,
        Collect = 2,
        Count = 3,
        CountB = 4,
        Step = 5,
        SetPause = 6,
        SetStepMul = 7,
        IsRunning = 9,
    }

    public static class Lua
    {
        /// <summary>
        /// Converts the acceptable index idx into an equivalent absolute index (that is, one that does not depend on the stack top). 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int AbsIndex(LuaState L, int i)
        {
            return LuaNative.lua_absindex(L, i);
        }

        /// <summary>
        /// Checks whether cond is true. If it is not, raises an error with a standard message (see luaL_argerror). 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="cond"></param>
        /// <param name="numarg"></param>
        /// <param name="extramsg"></param>
        public static void ArgCheck(LuaState L, bool cond, int numarg, string extramsg)
        {
            LuaNative.luaL_argcheck(L, cond, numarg, extramsg);
        }

        /// <summary>
        /// Raises an error reporting a problem with argument arg of the C function that called it, using a standard message that includes extramsg as a comment.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numarg"></param>
        /// <param name="extramsg"></param>
        /// <returns></returns>
        public static int ArgError(LuaState L, int numarg, string extramsg)
        {
            return LuaNative.luaL_argerror(L, numarg, extramsg);
        }

        /// <summary>
        /// Sets a new panic function and returns the old one.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="panicf"></param>
        /// <returns></returns>
        public static LuaFunction AtPanic(LuaState L, LuaFunction panicf)
        {
            return LuaNative.lua_atpanic(L, panicf);
        }

        /// <summary>
        /// Calls a function.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nargs"></param>
        /// <param name="nresults"></param>
        public static void Call(LuaState L, int nargs, int nresults)
        {
            LuaNative.lua_call(L, nargs, nresults);
        }

        /// <summary>
        /// Calls a metamethod. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int CallMeta(LuaState L, int obj, string e)
        {
            return LuaNative.luaL_callmeta(L, obj, e);
        }

        /// <summary>
        /// Checks whether the function has an argument of any type (including nil) at position arg. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        public static void CheckAny(LuaState L, int narg)
        {
            LuaNative.luaL_checkany(L, narg);
        }

        /// <summary>
        /// Checks whether the function argument narg is a number and returns this number cast to an int. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CheckInt(LuaState L, int n)
        {
            return LuaNative.luaL_checkint(L, n);
        }

        /// <summary>
        /// Checks whether the function argument narg is a number and returns this number cast to a lua_Integer. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numArg"></param>
        /// <returns></returns>
        public static long CheckInteger(LuaState L, int numArg)
        {
            return LuaNative.luaL_checkinteger(L, numArg);
        }

        /// <summary>
        /// Checks whether the function argument narg is a number and returns this number cast to a long. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long CheckLong(LuaState L, int n)
        {
            return LuaNative.luaL_checklong(L, n);
        }

        /// <summary>
        /// Checks whether the function argument arg is a string and returns this string; if l is not NULL fills 'l' with the string's length. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numArg"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string CheckLString(LuaState L, int numArg, ref ulong l)
        {
            return LuaNative.luaL_checklstring_(L, numArg, ref l);
        }

        /// <summary>
        /// Checks whether the function argument arg is a number and returns this number. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numArg"></param>
        /// <returns></returns>
        public static double CheckNumber(LuaState L, int numArg)
        {
            return LuaNative.luaL_checknumber(L, numArg);
        }

        /// <summary>
        /// Checks whether the function argument arg is a string and searches for this string in the array lst (which must be NULL-terminated). Returns the index in the array where the string was found. Raises an error if the argument is not a string or if the string cannot be found. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <param name="def"></param>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static int CheckOption(LuaState L, int narg, string def, string[] lst)
        {
            return LuaNative.luaL_checkoption(L, narg, def, lst);
        }

        /// <summary>
        /// Ensures that the stack has space for at least n extra slots (that is, that you can safely push up to n values into it). It returns false if it cannot fulfill the request, either because it would cause the stack to be larger than a fixed maximum size (typically at least several thousand elements) or because it cannot allocate memory for the extra space. This function never shrinks the stack; if the stack already has space for the extra slots, it is left unchanged. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="sz"></param>
        /// <returns></returns>
        public static int CheckStack(LuaState L, int sz)
        {
            return LuaNative.lua_checkstack(L, sz);
        }

        /// <summary>
        /// Checks whether the function argument arg is a string and returns this string. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string CheckString(LuaState L, int n)
        {
            return LuaNative.luaL_checkstring(L, n);
        }

        /// <summary>
        /// Checks whether the function argument arg has type t. See lua_type for the encoding of types for t. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <param name="t"></param>
        public static void CheckType(LuaState L, int narg, int t)
        {
            LuaNative.luaL_checktype(L, narg, t);
        }

        /// <summary>
        /// Checks whether the function argument arg is a userdata of the type tname (see luaL_newmetatable) and returns the userdata address (see lua_touserdata). 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ud"></param>
        /// <param name="tname"></param>
        /// <returns></returns>
        public static IntPtr CheckUData(LuaState L, int ud, string tname)
        {
            return LuaNative.luaL_checkudata(L, ud, tname);
        }

        /// <summary>
        /// Destroys all objects in the given Lua state (calling the corresponding garbage-collection metamethods, if any) and frees all dynamic memory used by this state. In several platforms, you may not need to call this function, because all resources are naturally released when the host program ends. On the other hand, long-running programs that create multiple states, such as daemons or web servers, will probably need to close states as soon as they are not needed. 
        /// </summary>
        /// <param name="L"></param>
        public static void Close(LuaState L)
        {
            LuaNative.lua_close(L);
        }

        /// <summary>
        /// Concatenates the n values at the top of the stack, pops them, and leaves the result at the top. If n is 1, the result is the single value on the stack (that is, the function does nothing); if n is 0, the result is the empty string. Concatenation is performed following the usual semantics of Lua.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        public static void Concat(LuaState L, int n)
        {
            LuaNative.lua_concat(L, n);
        }

        /// <summary>
        /// Copies the element at index fromidx into the valid index toidx, replacing the value at that position. Values at other positions are not affected. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="fromidx"></param>
        /// <param name="toidx"></param>
        public static void Copy(LuaState L, int fromidx, int toidx)
        {
            LuaNative.lua_copy(L, fromidx, toidx);
        }

        /// <summary>
        /// Calls the C function func in protected mode. func starts with only one element in its stack, a light userdata containing ud. In case of errors, lua_cpcall returns the same error codes as lua_pcall, plus the error object on the top of the stack; otherwise, it returns zero, and does not change the stack. All values returned by func are discarded. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="func"></param>
        /// <param name="ud"></param>
        /// <returns></returns>
        public static int CPCall(LuaState L, LuaFunction func, IntPtr ud)
        {
            return LuaNative.lua_cpcall(L, func, ud);
        }

        /// <summary>
        /// Creates a new empty table and pushes it onto the stack. The new table has space pre-allocated for narr array elements and nrec non-array elements. This pre-allocation is useful when you know exactly how many elements the table will have. Otherwise you can use the function lua_newtable. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narr"></param>
        /// <param name="nrec"></param>
        public static void CreateTable(LuaState L, int narr, int nrec)
        {
            LuaNative.lua_createtable(L, narr, nrec);
        }

        /// <summary>
        /// Loads and runs the given file. Returns 0 if there are no errors or 1 in case of errors. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static int DoFile(LuaState L, string filename)
        {
            return LuaNative.luaL_dofile(L, filename);
        }

        /// <summary>
        /// Loads and runs the given string. Returns 0 if there are no errors or 1 in case of errors. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int DoString(LuaState L, string s)
        {
            return LuaNative.luaL_dostring(L, s);
        }

        /// <summary>
        /// Dumps a function as a binary chunk. Receives a Lua function on the top of the stack and produces a binary chunk that, if loaded again, results in a function equivalent to the one dumped. As it produces parts of the chunk, lua_dump calls function writer (see lua_Writer) with the given data to write them. The value returned is the error code returned by the last call to the writer; 0 means no errors. This function does not pop the Lua function from the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="writer"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Dump(LuaState L, LuaWriter writer, IntPtr data)
        {
            return LuaNative.lua_dump(L, writer, data);
        }

        /// <summary>
        /// Returns 1 if the two values in acceptable indices index1 and index2 are equal, following the semantics of the Lua == operator (that is, may call metamethods). Otherwise returns 0. Also returns 0 if any of the indices is non valid. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx1"></param>
        /// <param name="idx2"></param>
        /// <returns></returns>
        public static int Equal(LuaState L, int idx1, int idx2)
        {
            return LuaNative.lua_equal(L, idx1, idx2);
        }

        /// <summary>
        /// Generates a Lua error. The error message (which can actually be a Lua value of any type) must be on the stack top. This function does a long jump, and therefore never returns. (see luaL_error). 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static int Error(LuaState L)
        {
            return LuaNative.lua_error(L);
        }

        /// <summary>
        /// Raises an error. The error message format is given by fmt plus any extra arguments, following the same rules of lua_pushfstring. It also adds at the beginning of the message the file name and the line number where the error occurred, if this information is available. This function never returns, but it is an idiom to use it in C functions as return luaL_error(args).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="fmt"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int Error(LuaState L, string fmt, string args)
        {
            return LuaNative.luaL_error(L, fmt, args);
        }

        /// <summary>
        /// This function produces the return values for process-related functions in the standard library (os.execute and io.close). 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="stat"></param>
        /// <returns></returns>
        public static int ExecResult(LuaState L, int stat)
        {
            return LuaNative.luaL_execresult(L, stat);
        }

        /// <summary>
        /// This function produces the return values for file-related functions in the standard library (io.open, os.rename, file:seek, etc.). 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="stat"></param>
        /// <param name="fname"></param>
        /// <returns></returns>
        public static int FileResult(LuaState L, int stat, string fname)
        {
            return LuaNative.luaL_fileresult(L, stat, fname);
        }

        /// <summary>
        /// No documentation available.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="fname"></param>
        /// <param name="szhint"></param>
        /// <returns></returns>
        public static string FindTable(LuaState L, int idx, string fname, int szhint)
        {
            return LuaNative.luaL_findtable_(L, idx, fname, szhint);
        }

        /// <summary>
        /// This function performs several tasks, according to the value of the parameter 'what'.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="what"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int GC(LuaState L, LuaGCParam what, int data)
        {
            return LuaNative.lua_gc(L, (int)what, data);
        }

        /// <summary>
        /// Returns the memory-allocation function of a given state. If ud is not NULL, Lua stores in *ud the opaque pointer given when the memory-allocator function was set. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ud"></param>
        /// <returns></returns>
        public static LuaAlloc GetAllocF(LuaState L, ref IntPtr ud)
        {
            return LuaNative.lua_getallocf(L, ref ud);
        }

        /// <summary>
        /// Pushes onto the stack the environment table of the value at the given index. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        public static void GetFEnv(LuaState L, int idx)
        {
            LuaNative.lua_getfenv(L, idx);
        }

        /// <summary>
        /// Pushes onto the stack the value t[k], where t is the value at the given valid index. As in Lua, this function may trigger a metamethod for the "index" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="k"></param>
        public static void GetField(LuaState L, int idx, string k)
        {
            LuaNative.lua_getfield(L, idx, k);
        }

        /// <summary>
        /// Pushes onto the stack the value t[k], where t is the value at the given valid index. As in Lua, this function may trigger a metamethod for the "index" event. Returns the LuaType of the field.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="k"></param>
        public static LuaType GetFieldWithType(LuaState L, int idx, string k)
        {
            return (LuaType)LuaNative.lua_getfield_with_type(L, idx, k);
        }

        /// <summary>
        /// Returns the memory in use by Lua.
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static int GetGCCount(LuaState L)
        {
            return LuaNative.lua_getgccount(L);
        }

        /// <summary>
        /// Pushes onto the stack the value of the global name.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="name"></param>
        public static void GetGlobal(LuaState L, string name)
        {
            LuaNative.lua_getglobal(L, name);
        }

        /// <summary>
        /// Pushes onto the stack the value of the global name.  Returns the type of that value. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="name"></param>
        public static LuaType GetGlobalWithType(LuaState L, string name)
        {
            return (LuaType)LuaNative.lua_getglobal_with_type(L, name);
        }

        /// <summary>
        /// Returns the current hook function. 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static LuaHook GetHook(LuaState L)
        {
            return LuaNative.lua_gethook(L);
        }

        /// <summary>
        /// Returns the current hook count. 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static int GetHookAccount(LuaState L)
        {
            return LuaNative.lua_gethookcount(L);
        }

        /// <summary>
        /// Returns the current hook mask. 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static int GetHookMask(LuaState L)
        {
            return LuaNative.lua_gethookmask(L);
        }

        /// <summary>
        /// Gets information about a specific function or function invocation. To get information about a function invocation, the parameter ar must be a valid activation record that was filled by a previous call to lua_getstack or given as argument to a hook (see lua_Hook).To get information about a function, you push it onto the stack and start the what string with the character '>'. (In that case, lua_getinfo pops the function from the top of the stack).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="what"></param>
        /// <param name="ar"></param>
        /// <returns></returns>
        public static int GetInfo(LuaState L, string what, LuaDebug ar)
        {
            return LuaNative.lua_getinfo(L, what, ar);
        }

        /// <summary>
        /// Pushes onto the stack the field e from the metatable of the object at index obj and returns the type of the pushed value. If the object does not have a metatable, or if the metatable does not have this field, pushes nothing and returns LUA_TNIL. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static LuaType GetMetaField(LuaState L, int obj, string e)
        {
            return (LuaType)LuaNative.luaL_getmetafield(L, obj, e);
        }

        /// <summary>
        /// Retrieves the metatable associated with tname from the registry.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        public static void GetMetaTable(LuaState L, string n)
        {
            LuaNative.luaL_getmetatable(L, n);
        }

        /// <summary>
        /// Pushes onto the stack the metatable of the value at the given acceptable index. If the index is not valid, or if the value does not have a metatable, the function returns 0 and pushes nothing on the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="objindex"></param>
        /// <returns></returns>
        public static int GetMetaTable(LuaState L, int objindex)
        {
            return LuaNative.lua_getmetatable(L, objindex);
        }

        /// <summary>
        /// Gets information about a local variable of a given activation record or a given function.In the first case, the parameter ar must be a valid activation record that was filled by a previous call to lua_getstack or given as argument to a hook (see lua_Hook). The index n selects which local variable to inspect; see debug.getlocal for details about variable indices and names. lua_getlocal pushes the variable's value onto the stack and returns its name. In the second case, ar must be NULL and the function to be inspected must be at the top of the stack. In this case, only parameters of Lua functions are visible (as there is no information about what variables are active) and no values are pushed onto the stack. Returns NULL (and pushes nothing) when the index is greater than the number of active local variables. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ar"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GetLocal(LuaState L, LuaDebug ar, int n)
        {
            return LuaNative.lua_getlocal_(L, ar, n);
        }

        /// <summary>
        /// No documentation available.
        /// </summary>
        /// <param name="L"></param>
        public static void GetRegistry(LuaState L)
        {
            LuaNative.lua_getregistry(L);
        }

        /// <summary>
        /// Gets information about the interpreter runtime stack. This function fills parts of a lua_Debug structure with an identification of the activation record of the function executing at a given level. Level 0 is the current running function, whereas level n+1 is the function that has called level n (except for tail calls, which do not count on the stack). When there are no errors, lua_getstack returns 1; when called with a level greater than the stack depth, it returns 0. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="level"></param>
        /// <param name="ar"></param>
        /// <returns></returns>
        public static int GetStack(LuaState L, int level, LuaDebug ar)
        {
            return LuaNative.lua_getstack(L, level, ar);
        }

        /// <summary>
        /// Ensures that the value t[fname], where t is the value at index idx, is a table, and pushes that table onto the stack. Returns true if it finds a previous table there and false if it creates a new table. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="i"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GetSubTable(LuaState L, int i, string name)
        {
            return LuaNative.luaL_getsubtable(L, i, name);
        }

        /// <summary>
        /// Pushes onto the stack the value t[k], where t is the value at the given index and k is the value at the top of the stack.This function pops the key from the stack, pushing the resulting value in its place. As in Lua, this function may trigger a metamethod for the "index" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        public static void GetTable(LuaState L, int idx)
        {
            LuaNative.lua_gettable(L, idx);
        }

        /// <summary>
        /// Returns the index of the top element in the stack. Because indices start at 1, this result is equal to the number of elements in the stack; in particular, 0 means an empty stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static int GetTop(LuaState L)
        {
            return LuaNative.lua_gettop(L);
        }

        /// <summary>
        /// Gets information about the n-th upvalue of the closure at index funcindex. It pushes the upvalue's value onto the stack and returns its name. Returns NULL (and pushes nothing) when the index n is greater than the number of upvalues. For C functions, this function uses the empty string "" as a name for all upvalues. (For Lua functions, upvalues are the external local variables that the function uses, and that are consequently included in its closure.) Upvalues have no particular order, as they are active through the whole function. They are numbered in an arbitrary order. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="funcindex"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GetUpValue(LuaState L, int funcindex, int n)
        {
            return LuaNative.lua_getupvalue_(L, funcindex, n);
        }

        /// <summary>
        /// Creates a copy of string s by replacing any occurrence of the string p with the string r. Pushes the resulting string on the stack and returns it.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static string GSub(LuaState L, string s, string p, string r)
        {
            return LuaNative.luaL_gsub_(L, s, p, r);
        }

        /// <summary>
        /// Moves the top element into the given valid index, shifting up the elements above this index to open space. This function cannot be called with a pseudo-index, because a pseudo-index is not an actual stack position. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        public static void Insert(LuaState L, int idx)
        {
            LuaNative.lua_insert(L, idx);
        }

        /// <summary>
        /// Returns true if the value at the given index is a boolean, and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsBoolean(LuaState L, int n)
        {
            return LuaNative.lua_isboolean(L, n);
        }

        /// <summary>
        /// Returns true if the value at the given index is a C function, and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static bool IsCFunction(LuaState L, int idx)
        {
            return LuaNative.lua_iscfunction(L, idx) > 0;
        }

        /// <summary>
        /// Returns true if the value at the given index is a function (either C or Lua), and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsFunction(LuaState L, int n)
        {
            return LuaNative.lua_isfunction(L, n);
        }

        /// <summary>
        /// Returns true if the value at the given index is a light userdata, and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsLightUserData(LuaState L, int n)
        {
            return LuaNative.lua_islightuserdata(L, n);
        }

        /// <summary>
        /// Returns true if the value at the given index is nil, and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsNil(LuaState L, int n)
        {
            return LuaNative.lua_isnil(L, n);
        }

        /// <summary>
        /// Returns true if the given index is not valid, and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsNone(LuaState L, int n)
        {
            return LuaNative.lua_isnone(L, n);
        }

        /// <summary>
        /// Returns true if the given index is not valid or if the value at this index is nil, and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsNoneOrNill(LuaState L, int n)
        {
            return LuaNative.lua_isnoneornil(L, n);
        }

        /// <summary>
        /// Returns true if the value at the given index is a number or a string convertible to a number, and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static bool IsNumber(LuaState L, int idx)
        {
            return LuaNative.lua_isnumber(L, idx) > 0;
        }

        /// <summary>
        /// Returns true if the value at the given index is a string or a number (which is always convertible to a string), and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static bool IsString(LuaState L, int idx)
        {
            return LuaNative.lua_isstring(L, idx) > 0;
        }

        /// <summary>
        /// Returns true if the value at the given index is a table, and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsTable(LuaState L, int n)
        {
            return LuaNative.lua_istable(L, n);
        }

        /// <summary>
        /// Returns true if the value at the given index is a thread, and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsThread(LuaState L, int n)
        {
            return LuaNative.lua_isthread(L, n);
        }

        /// <summary>
        /// Returns true if the value at the given index is a userdata (either full or light), and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static bool IsUserData(LuaState L, int idx)
        {
            return LuaNative.lua_isuserdata(L, idx) > 0;
        }

        /// <summary>
        /// Returns true if the given coroutine can yield, and false otherwise. 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static bool IsYieldable(LuaState L)
        {
            return LuaNative.lua_isyieldable(L) > 0;
        }

        /// <summary>
        /// No documentation available.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx1"></param>
        /// <param name="idx2"></param>
        /// <returns></returns>
        public static int LessThan(LuaState L, int idx1, int idx2)
        {
            return LuaNative.lua_lessthan(L, idx1, idx2);
        }

        /// <summary>
        ///Loads a Lua chunk without running it. If there are no errors, lua_load pushes the compiled chunk as a Lua function on top of the stack. Otherwise, it pushes an error message.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="reader"></param>
        /// <param name="dt"></param>
        /// <param name="chunkname"></param>
        /// <returns></returns>
        public static int Load(LuaState L, LuaReader reader, IntPtr dt, string chunkname)
        {
            return LuaNative.lua_load(L, reader, dt, chunkname);
        }

        /// <summary>
        /// Equivalent to luaL_loadbufferx with mode equal to NULL. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="buff"></param>
        /// <param name="sz"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int LoadBuffer(LuaState L, string buff, ulong sz, string name)
        {
            return LuaNative.luaL_loadbuffer(L, buff, sz, name);
        }

        /// <summary>
        /// Loads a buffer as a Lua chunk. This function uses lua_load to load the chunk in the buffer pointed to by buff with size sz. This function returns the same results as lua_load. name is the chunk name, used for debug information and error messages. The string mode works as in function lua_load.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="buffer"></param>
        /// <param name="size"></param>
        /// <param name="name"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static int LoadBufferEx(LuaState L, string buffer, ulong size, string name, string mode)
        {
            return LuaNative.luaL_loadbufferx(L, buffer, size, name, mode);
        }

        /// <summary>
        /// Equivalent to luaL_loadfilex with mode equal to NULL. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static int LoadFile(LuaState L, string filename)
        {
            return LuaNative.luaL_loadfile(L, filename);
        }

        /// <summary>
        /// Loads a file as a Lua chunk. This function uses lua_load to load the chunk in the file named filename. If filename is NULL, then it loads from the standard input. The first line in the file is ignored if it starts with a #. The string mode works as in function lua_load. This function returns the same results as lua_load, but it has an extra error code LUA_ERRFILE for file-related errors (e.g., it cannot open or read the file). As lua_load, this function only loads the chunk; it does not run it. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="filename"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static int LoadFileEx(LuaState L, string filename, string mode)
        {
            return LuaNative.luaL_loadfilex(L, filename, mode);
        }

        /// <summary>
        /// Loads a string as a Lua chunk. This function uses lua_load to load the chunk in the zero-terminated string s. This function returns the same results as lua_load. Also as lua_load, this function only loads the chunk; it does not run it. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LoadString(LuaState L, string s)
        {
            return LuaNative.luaL_loadstring(L, s);
        }

        /// <summary>
        /// No documentation available.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="reader"></param>
        /// <param name="dt"></param>
        /// <param name="chunkname"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static int LoadX(LuaState L, LuaReader reader, IntPtr dt, string chunkname, string mode)
        {
            return LuaNative.lua_loadx(L, reader, dt, chunkname, mode);
        }

        /// <summary>
        /// If the registry already has the key tname, returns 0. Otherwise, creates a new table to be used as a metatable for userdata, adds to this new table the pair __name = tname, adds to the registry the pair [tname] = new table, and returns 1. (The entry __name is used by some error-reporting functions.) In both cases pushes onto the stack the final value associated with tname in the registry. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="tname"></param>
        /// <returns></returns>
        public static int NewMetaTable(LuaState L, string tname)
        {
            return LuaNative.luaL_newmetatable(L, tname);
        }

        /// <summary>
        /// Creates a new Lua state. It calls lua_newstate with an allocator based on the standard C realloc function and then sets a panic function (see §4.6) that prints an error message to the standard error output in case of fatal errors. Returns the new state, or NULL if there is a memory allocation error. 
        /// </summary>
        /// <returns></returns>
        public static LuaState NewState()
        {
            return LuaNative.luaL_newstate();
        }

        /// <summary>
        /// Creates a new thread running in a new, independent state. Returns NULL if it cannot create the thread or the state (due to lack of memory). The argument f is the allocator function; Lua does all memory allocation for this state through this function (see lua_Alloc). The second argument, ud, is an opaque pointer that Lua passes to the allocator in every call. 
        /// </summary>
        /// <param name="f"></param>
        /// <param name="ud"></param>
        /// <returns></returns>
        public static LuaState NewState(LuaAlloc f, IntPtr ud)
        {
            return LuaNative.lua_newstate(f, ud);
        }

        /// <summary>
        /// Creates a new empty table and pushes it onto the stack. It is equivalent to lua_createtable(L, 0, 0). 
        /// </summary>
        /// <param name="L"></param>
        public static void NewTable(LuaState L)
        {
            LuaNative.lua_newtable(L);
        }

        /// <summary>
        /// Creates a new thread, pushes it on the stack, and returns a pointer to a lua_State that represents this new thread. The new thread returned by this function shares with the original thread its global environment, but has an independent execution stack. There is no explicit function to close or to destroy a thread. Threads are subject to garbage collection, like any Lua object. 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static LuaState NewThread(LuaState L)
        {
            return LuaNative.lua_newthread(L);
        }

        /// <summary>
        /// This function allocates a new block of memory with the given size, pushes onto the stack a new full userdata with the block address, and returns this address. The host program can freely use this memory. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="sz"></param>
        /// <returns></returns>
        public static IntPtr NewUserData(LuaState L, UInt64 sz)
        {
            return LuaNative.lua_newuserdata(L, sz);
        }

        /// <summary>
        /// Pops a key from the stack, and pushes a key–value pair from the table at the given index (the "next" pair after the given key). If there are no more elements in the table, then lua_next returns 0 (and pushes nothing). 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static int Next(LuaState L, int idx)
        {
            return LuaNative.lua_next(L, idx);
        }

        /// <summary>
        /// Returns the "length" of the value at the given acceptable index: for strings, this is the string length; for tables, this is the result of the length operator ('#'); for userdata, this is the size of the block of memory allocated for the userdata; for other values, it is 0. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static UInt64 ObjLen(LuaState L, int idx)
        {
            return LuaNative.lua_objlen(L, idx);
        }

        /// <summary>
        /// Creates a new environment (or state). When lua_open creates a fresh environment, this environment contains no predefined functions, not even print. To keep Lua small, all standard libraries are provided as separate packages, so that you do not have to use them if you do not need to. The header file lualib.h defines functions to open the libraries. The call to luaopen_io, for instance, creates the io table and registers the I/O functions (io.read, io.write, etc.) inside it. 
        /// </summary>
        /// <returns></returns>
        public static LuaState Open()
        {
            return LuaNative.lua_open();
        }

        /// <summary>
        /// Opens the Base library.
        /// </summary>
        /// <param name="L"></param>
        public static void OpenBase(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_base);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// Opens the Bit library.
        /// </summary>
        /// <param name="L"></param>
        public static void OpenBit(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_bit);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// Opens the Debug library.
        /// </summary>
        /// <param name="L"></param>
        public static void OpenDebug(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_debug);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// Opens the FFI library
        /// </summary>
        /// <param name="L"></param>
        public static void OpenFFI(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_ffi);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// Opens the IO library
        /// </summary>
        /// <param name="L"></param>
        public static void OpenIO(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_io);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// Opens the JIT library
        /// </summary>
        /// <param name="L"></param>
        public static void OpenJIT(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_jit);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// No documentation available.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="libname"></param>
        /// <param name="l"></param>
        /// <param name="nup"></param>
        public static void OpenLib(LuaState L, string libname, LuaLReg l, int nup)
        {
            LuaNative.luaL_openlib(L, libname, l, nup);
        }

        /// <summary>
        /// Opens all standard Lua libraries into the given state. 
        /// </summary>
        /// <param name="L"></param>
        public static void OpenLibs(LuaState L)
        {
            LuaNative.luaL_openlibs(L);
        }

        /// <summary>
        /// Opens the Math library.
        /// </summary>
        /// <param name="L"></param>
        public static void OpenMath(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_math);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// Opens the OS library.
        /// </summary>
        /// <param name="L"></param>
        public static void OpenOS(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_os);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// Opens the Package library.
        /// </summary>
        /// <param name="L"></param>
        public static void OpenPackage(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_package);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// Opens the String library.
        /// </summary>
        /// <param name="L"></param>
        public static void OpenString(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_string);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// Opens the StringBuffer library.
        /// </summary>
        /// <param name="L"></param>
        public static void OpenStringBuffer(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_string_buffer);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// Opens the Table library.
        /// </summary>
        /// <param name="L"></param>
        public static void OpenTable(LuaState L)
        {
            LuaNative.lua_pushcfunction(L, LuaNative.luaopen_table);
            LuaNative.lua_call(L, 0, 0);
        }

        /// <summary>
        /// If the function argument narg is a number, returns this number cast to an int. If this argument is absent or is nil, returns d. Otherwise, raises an error. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int OptInt(LuaState L, int n, long d)
        {
            return LuaNative.luaL_optint(L, n, d);
        }

        /// <summary>
        /// If the function argument narg is a number, returns this number cast to a lua_Integer. If this argument is absent or is nil, returns d. Otherwise, raises an error. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nArg"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static long OptInteger(LuaState L, int nArg, long def)
        {
            return LuaNative.luaL_optinteger(L, nArg, def);
        }

        /// <summary>
        /// If the function argument narg is a number, returns this number cast to a long. If this argument is absent or is nil, returns d. Otherwise, raises an error. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static long OptLong(LuaState L, int n, long d)
        {
            return LuaNative.luaL_optlong(L, n, d);
        }

        /// <summary>
        /// If the function argument narg is a string, returns this string. If this argument is absent or is nil, returns d. Otherwise, raises an error. If l is not NULL, fills the position *l with the results's length. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numArg"></param>
        /// <param name="def"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string OptLString(LuaState L, int numArg, string def, ref ulong l)
        {
            return LuaNative.luaL_optlstring_(L, numArg, def, ref l);
        }

        /// <summary>
        /// If the function argument narg is a number, returns this number. If this argument is absent or is nil, returns d. Otherwise, raises an error. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nArg"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static double OptNumber(LuaState L, int nArg, double def)
        {
            return LuaNative.luaL_optnumber(L, nArg, def);
        }

        /// <summary>
        /// If the function argument narg is a string, returns this string. If this argument is absent or is nil, returns d. Otherwise, raises an error.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string OptString(LuaState L, int n, string d)
        {
            return LuaNative.luaL_optstring(L, n, d);
        }

        /// <summary>
        /// Calls a function in protected mode. Both nargs and nresults have the same meaning as in lua_call. If there are no errors during the call, lua_pcall behaves exactly like lua_call. However, if there is any error, lua_pcall catches it, pushes a single value on the stack (the error object), and returns an error code. Like lua_call, lua_pcall always removes the function and its arguments from the stack. If msgh is 0, then the error object returned on the stack is exactly the original error object. Otherwise, msgh is the stack index of a message handler. (This index cannot be a pseudo-index.) In case of runtime errors, this function will be called with the error object and its return value will be the object returned on the stack by lua_pcall. Typically, the message handler is used to add more debug information to the error object, such as a stack traceback. Such information cannot be gathered after the return of lua_pcall, since by then the stack has unwound.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nargs"></param>
        /// <param name="nresults"></param>
        /// <param name="errfunc"></param>
        /// <returns></returns>
        public static int PCall(LuaState L, int nargs, int nresults, int errfunc)
        {
            return LuaNative.lua_pcall(L, nargs, nresults, errfunc);
        }

        /// <summary>
        /// Pops n elements from the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        public static void Pop(LuaState L, int n)
        {
            LuaNative.lua_pop(L, n);
        }

        /// <summary>
        /// No documentation available.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="fmt"></param>
        /// <param name="depth"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string ProfileDumpStack(LuaState L, string fmt, int depth, ref ulong len)
        {
            return LuaNative.luaJIT_profile_dumpstack_(L, fmt, depth, ref len);
        }

        /// <summary>
        /// No documentation available.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="mode"></param>
        /// <param name="cb"></param>
        /// <param name="data"></param>
        public static void ProfileStart(LuaState L, string mode, LuaJITProfileCallback cb, IntPtr data)
        {
            LuaNative.luaJIT_profile_start(L, mode, cb, data);
        }

        /// <summary>
        /// No documentation available.
        /// </summary>
        /// <param name="L"></param>
        public static void ProfileStop(LuaState L)
        {
            LuaNative.luaJIT_profile_stop(L);
        }

        /// <summary>
        /// Pushes a boolean value with value b onto the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="b"></param>
        public static void PushBoolean(LuaState L, bool b)
        {
            LuaNative.lua_pushboolean(L, b ? 1 : 0);
        }

        /// <summary>
        /// Pushes a new C closure onto the stack. When a C function is created, it is possible to associate some values with it, thus creating a C closure (see §4.4); these values are then accessible to the function whenever it is called. To associate values with a C function, first these values must be pushed onto the stack (when there are multiple values, the first value is pushed first). Then lua_pushcclosure is called to create and push the C function onto the stack, with the argument n telling how many values will be associated with the function. lua_pushcclosure also pops these values from the stack. The maximum value for n is 255. When n is zero, this function creates a light C function, which is just a pointer to the C function. In that case, it never raises a memory error. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="fn"></param>
        /// <param name="n"></param>
        public static void PushCClosure(LuaState L, LuaFunction fn, int n)
        {
            LuaNative.lua_pushcclosure(L, fn, n);
        }

        /// <summary>
        /// Sets the C function f as the new value of global name.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="f"></param>
        public static void PushCFunction(LuaState L, LuaFunction f)
        {
            LuaNative.lua_pushcfunction(L, f);
        }

        /// <summary>
        /// Pushes an integer with value n onto the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        public static void PushInteger(LuaState L, Int64 n)
        {
            LuaNative.lua_pushinteger(L, n);
        }

        /// <summary>
        /// Equivalent to lua_pushstring, but should be used only when s is a literal string. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        public static void PushLiteral(LuaState L, string s)
        {
            LuaNative.lua_pushliteral(L, s);
        }

        /// <summary>
        /// Find or create a module table with a given name. The function first looks at the LOADED table and, if that fails, try a global variable with that name. In any case, leaves on the stack the module table.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="modename"></param>
        /// <param name="sizehint"></param>
        public static void PushModule(LuaState L, string modename, int sizehint)
        {
            LuaNative.luaL_pushmodule(L, modename, sizehint);
        }

        /// <summary>
        /// Pushes a light userdata onto the stack. Userdata represent C values in Lua. A light userdata represents a pointer, a void*. It is a value (like a number): you do not create it, it has no individual metatable, and it is not collected (as it was never created). A light userdata is equal to "any" light userdata with the same C address. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="p"></param>
        public static void PushLightUserData(LuaState L, IntPtr p)
        {
            LuaNative.lua_pushlightuserdata(L, p);
        }

        /// <summary>
        /// Pushes the string pointed to by s with size len onto the stack. Lua makes (or reuses) an internal copy of the given string, so the memory at s can be freed or reused immediately after the function returns. The string can contain any binary data, including embedded zeros.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <param name="l"></param>
        public static void PushLString(LuaState L, string s, UInt64 l)
        {
            LuaNative.lua_pushlstring(L, s, l);
        }

        /// <summary>
        /// Pushes a nil value onto the stack. 
        /// </summary>
        /// <param name="L"></param>
        public static void PushNil(LuaState L)
        {
            LuaNative.lua_pushnil(L);
        }

        /// <summary>
        /// Pushes a float with value n onto the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        public static void PushNumber(LuaState L, double n)
        {
            LuaNative.lua_pushnumber(L, n);
        }

        /// <summary>
        /// Pushes the zero-terminated string pointed to by s onto the stack. Lua makes (or reuses) an internal copy of the given string, so the memory at s can be freed or reused immediately after the function returns. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        public static void PushString(LuaState L, string s)
        {
            LuaNative.lua_pushstring(L, s);
        }

        /// <summary>
        /// Pushes the thread represented by L onto the stack. Returns 1 if this thread is the main thread of its state. 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static int PushThread(LuaState L)
        {
            return LuaNative.lua_pushthread(L);
        }

        /// <summary>
        /// Pushes a copy of the element at the given index onto the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        public static void PushValue(LuaState L, int idx)
        {
            LuaNative.lua_pushvalue(L, idx);
        }

        /// <summary>
        /// No documentation available.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string QL(string x)
        {
            return LuaNative.LUA_QL(x);
        }

        /// <summary>
        /// Returns 1 if the two values in indices index1 and index2 are primitively equal (that is, without calling the __eq metamethod). Otherwise returns 0. Also returns 0 if any of the indices are not valid. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx1"></param>
        /// <param name="idx2"></param>
        /// <returns></returns>
        public static int RawEqual(LuaState L, int idx1, int idx2)
        {
            return LuaNative.lua_rawequal(L, idx1, idx2);
        }

        /// <summary>
        /// Similar to lua_gettable, but does a raw access (i.e., without metamethods). 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        public static void RawGet(LuaState L, int idx)
        {
            LuaNative.lua_rawget(L, idx);
        }

        /// <summary>
        /// Pushes onto the stack the value t[n], where t is the table at the given index. The access is raw, that is, it does not invoke the __index metamethod. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="n"></param>
        public static void RawGetI(LuaState L, int idx, int n)
        {
            LuaNative.lua_rawgeti(L, idx, n);
        }

        /// <summary>
        /// Similar to lua_settable, but does a raw assignment (i.e., without metamethods). 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        public static void RawSet(LuaState L, int idx)
        {
            LuaNative.lua_rawset(L, idx);
        }

        /// <summary>
        /// Does the equivalent of t[i] = v, where t is the table at the given index and v is the value at the top of the stack. This function pops the value from the stack. The assignment is raw, that is, it does not invoke the __newindex metamethod. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="n"></param>
        public static void RawSetI(LuaState L, int idx, int n)
        {
            LuaNative.lua_rawseti(L, idx, n);
        }

        /// <summary>
        /// Creates and returns a reference, in the table at index t, for the object at the top of the stack (and pops the object). A reference is a unique integer key. As long as you do not manually add integer keys into table t, luaL_ref ensures the uniqueness of the key it returns. You can retrieve an object referred by reference r by calling lua_rawgeti(L, t, r). Function luaL_unref frees a reference and its associated object. If the object at the top of the stack is nil, luaL_ref returns the constant LUA_REFNIL. The constant LUA_NOREF is guaranteed to be different from any reference returned by luaL_ref. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int Ref(LuaState L, int t)
        {
            return LuaNative.luaL_ref(L, t);
        }

        /// <summary>
        /// Opens a library. When called with libname equal to NULL, it simply registers all functions in the list l (see luaL_Reg) into the table on the top of the stack. When called with a non-null libname, luaL_register creates a new table t, sets it as the value of the global variable libname, sets it as the value of package.loaded[libname], and registers on it all functions in the list l. If there is a table in package.loaded[libname] or in variable libname, reuses this table instead of creating a new one. In any case the function leaves the table on the top of the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="libname"></param>
        /// <param name="l"></param>
        public static void Register(LuaState L, string libname, LuaLReg l)
        {
            LuaNative.luaL_register(L, libname, l);
        }

        /// <summary>
        /// Sets the C function f as the new value of global name.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <param name="f"></param>
        public static void Register(LuaState L, string n, LuaFunction f)
        {
            LuaNative.lua_register(L, n, f);
        }

        /// <summary>
        /// Removes the element at the given valid index, shifting down the elements above this index to fill the gap. This function cannot be called with a pseudo-index, because a pseudo-index is not an actual stack position. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        public static void Remove(LuaState L, int idx)
        {
            LuaNative.lua_remove(L, idx);
        }

        /// <summary>
        /// Moves the top element into the given valid index without shifting any element (therefore replacing the value at that given index), and then pops the top element. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        public static void Replace(LuaState L, int idx)
        {
            LuaNative.lua_replace(L, idx);
        }

        /// <summary>
        /// If modname is not already present in package.loaded, calls function openf with string modname as an argument and sets the call result in package.loaded[modname], as if that function has been called through require. If glb is true, also stores the module into global modname. Leaves a copy of the module on the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="modname"></param>
        /// <param name="openf"></param>
        /// <param name="glb"></param>
        public static void RequireF(LuaState L, string modname, LuaFunction openf, int glb)
        {
            LuaNative.luaL_requiref(L, modname, openf, glb);
        }

        /// <summary>
        /// Starts and resumes a coroutine in the given thread L. To start a coroutine, you push onto the thread stack the main function plus any arguments; then you call lua_resume, with nargs being the number of arguments. This call returns when the coroutine suspends or finishes its execution. When it returns, the stack contains all values passed to lua_yield, or all values returned by the body function. lua_resume returns LUA_YIELD if the coroutine yields, LUA_OK if the coroutine finishes its execution without errors, or an error code in case of errors (see lua_pcall). In case of errors, the stack is not unwound, so you can use the debug API over it. The error object is on the top of the stack. To resume a coroutine, you remove any results from the last lua_yield, put on its stack only the values to be passed as results from yield, and then call lua_resume. The parameter from represents the coroutine that is resuming L. If there is no such coroutine, this parameter can be NULL. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <returns></returns>
        public static int Resume(LuaState L, int narg)
        {
            return LuaNative.lua_resume(L, narg);
        }

        /// <summary>
        /// Changes the allocator function of a given state to f with user data ud. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="f"></param>
        /// <param name="ud"></param>
        public static void SetAllocF(LuaState L, LuaAlloc f, IntPtr ud)
        {
            LuaNative.lua_setallocf(L, f, ud);
        }

        /// <summary>
        /// Pops a table from the stack and sets it as the new environment for the value at the given index. If the value at the given index is neither a function nor a thread nor a userdata, lua_setfenv returns 0. Otherwise it returns 1.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static int SetFEnv(LuaState L, int idx)
        {
            return LuaNative.lua_setfenv(L, idx);
        }

        /// <summary>
        /// Does the equivalent to t[k] = v, where t is the value at the given index and v is the value at the top of the stack. This function pops the value from the stack. As in Lua, this function may trigger a metamethod for the "newindex" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="k"></param>
        public static void SetField(LuaState L, int idx, string k)
        {
            LuaNative.lua_setfield(L, idx, k);
        }

        /// <summary>
        /// Registers all functions in the array l (see luaL_Reg) into the table on the top of the stack (below optional upvalues, see next). When nup is not zero, all functions are created sharing nup upvalues, which must be previously pushed on the stack on top of the library table. These values are popped from the stack after the registration. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="l"></param>
        /// <param name="nup"></param>
        public static void SetFuncs(LuaState L, LuaLReg[] l, int nup)
        {
            LuaNative.luaL_setfuncs(L, l, nup);
        }

        /// <summary>
        /// Pops a value from the stack and sets it as the new value of global name. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="name"></param>
        public static void SetGlobal(LuaState L, string name)
        {
            LuaNative.lua_setglobal(L, name);
        }

        /// <summary>
        /// Sets the debugging hook function. Argument f is the hook function. mask specifies on which events the hook will be called: it is formed by a bitwise OR of the constants LUA_MASKCALL, LUA_MASKRET, LUA_MASKLINE, and LUA_MASKCOUNT. The count argument is only meaningful when the mask includes LUA_MASKCOUNT.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="func"></param>
        /// <param name="mask"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int SetHook(LuaState L, LuaHook func, int mask, int count)
        {
            return LuaNative.lua_sethook(L, func, mask, count);
        }

        /// <summary>
        /// Sets the metatable of the object at the top of the stack as the metatable associated with name tname in the registry (see luaL_newmetatable). 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="tname"></param>
        public static void SetMetaTable(LuaState L, string tname)
        {
            LuaNative.luaL_setmetatable(L, tname);
        }

        /// <summary>
        /// Pops a table from the stack and sets it as the new metatable for the value at the given index. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="objindex"></param>
        /// <returns></returns>
        public static int SetMetaTable(LuaState L, int objindex)
        {
            return LuaNative.lua_setmetatable(L, objindex);
        }

        /// <summary>
        /// Documentation not available.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public static void SetLevel(LuaState from, LuaState to)
        {
            LuaNative.lua_setlevel(from, to);
        }

        /// <summary>
        /// Sets the value of a local variable of a given activation record. It assigns the value at the top of the stack to the variable and returns its name. It also pops the value from the stack. Returns NULL (and pops nothing) when the index is greater than the number of active local variables. Parameters ar and n are as in function lua_getlocal. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ar"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string SetLocal(LuaState L, LuaDebug ar, int n)
        {
            return LuaNative.lua_setlocal_(L, ar, n);
        }

        /// <summary>
        /// Does the equivalent to t[k] = v, where t is the value at the given index, v is the value at the top of the stack, and k is the value just below the top. This function pops both the key and the value from the stack. As in Lua, this function may trigger a metamethod for the "newindex" event.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        public static void SetTable(LuaState L, int idx)
        {
            LuaNative.lua_settable(L, idx);
        }

        /// <summary>
        /// Accepts any index, or 0, and sets the stack top to this index. If the new top is larger than the old one, then the new elements are filled with nil. If index is 0, then all stack elements are removed. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        public static void SetTop(LuaState L, int idx)
        {
            LuaNative.lua_settop(L, idx);
        }

        /// <summary>
        /// Sets the value of a closure's upvalue. It assigns the value at the top of the stack to the upvalue and returns its name. It also pops the value from the stack. Returns NULL (and pops nothing) when the index n is greater than the number of upvalues. Parameters funcindex and n are as in function lua_getupvalue. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="funcindex"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string SetUpValue(LuaState L, int funcindex, int n)
        {
            return LuaNative.lua_setupvalue_(L, funcindex, n);
        }

        /// <summary>
        /// Returns the status of the thread L. The status can be 0 (LUA_OK) for a normal thread, an error code if the thread finished the execution of a lua_resume with an error, or LUA_YIELD if the thread is suspended. You can only call functions in threads with status LUA_OK. You can resume threads with status LUA_OK (to start a new coroutine) or LUA_YIELD (to resume a coroutine). 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static int Status(LuaState L)
        {
            return LuaNative.lua_status(L);
        }

        /// <summary>
        /// Any string that lua_tostring returns always has a zero at its end, but it can have other zeros inside it. The lua_strlen function returns the correct length of the string
        /// </summary>
        /// <param name="L"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static ulong StrLen(LuaState L, int i)
        {
            return LuaNative.lua_strlen(L, i);
        }

        /// <summary>
        /// This function works like luaL_checkudata, except that, when the test fails, it returns NULL instead of raising an error. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ud"></param>
        /// <param name="tname"></param>
        /// <returns></returns>
        public static IntPtr TestUData(LuaState L, int ud, string tname)
        {
            return LuaNative.luaL_testudata(L, ud, tname);
        }

        /// <summary>
        /// Converts the Lua value at the given index to a C boolean value (0 or 1). Like all tests in Lua, lua_toboolean returns true for any Lua value different from false and nil; otherwise it returns false. (If you want to accept only actual boolean values, use lua_isboolean to test the value's type.) 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static bool ToBoolean(LuaState L, int idx)
        {
            return LuaNative.lua_toboolean(L, idx) > 0 ? true : false;
        }

        /// <summary>
        /// Converts a value at the given index to a C function. That value must be a C function; otherwise, returns NULL. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static LuaFunction ToCFunction(LuaState L, int idx)
        {
            return LuaNative.lua_tocfunction(L, idx);
        }

        /// <summary>
        /// Equivalent to lua_tointegerx with isnum equal to NULL. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static Int64 ToInteger(LuaState L, int idx)
        {
            return LuaNative.lua_tointeger(L, idx);
        }

        /// <summary>
        /// Converts the Lua value at the given index to the signed integral type lua_Integer. The Lua value must be an integer, or a number or string convertible to an integer; otherwise, lua_tointegerx returns 0. If isnum is not NULL, its referent is assigned a boolean value that indicates whether the operation succeeded. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="isnum"></param>
        /// <returns></returns>
        public static long ToIntegerX(LuaState L, int idx, ref int isnum)
        {
            return LuaNative.lua_tointegerx(L, idx, ref isnum);
        }

        /// <summary>
        /// Converts the Lua value at the given index to a C string. If len is not NULL, it sets *len with the string length. The Lua value must be a string or a number; otherwise, the function returns NULL. If the value is a number, then lua_tolstring also changes the actual value in the stack to a string. (This change confuses lua_next when lua_tolstring is applied to keys during a table traversal.) lua_tolstring returns a pointer to a string inside the Lua state. This string always has a zero ('\0') after its last character (as in C), but can contain other zeros in its body. Because Lua has garbage collection, there is no guarantee that the pointer returned by lua_tolstring will be valid after the corresponding Lua value is removed from the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string ToLString(LuaState L, int idx, ref ulong len)
        {
            return LuaNative.lua_tolstring_(L, idx, ref len);
        }

        /// <summary>
        /// Equivalent to lua_tonumberx with isnum equal to NULL. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static double ToNumber(LuaState L, int idx)
        {
            return LuaNative.lua_tonumber(L, idx);
        }

        /// <summary>
        /// Converts the Lua value at the given index to the C type lua_Number. The Lua value must be a number or a string convertible to a number (see §3.4.3); otherwise, lua_tonumberx returns 0. If isnum is not NULL, its referent is assigned a boolean value that indicates whether the operation succeeded. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="isnum"></param>
        /// <returns></returns>
        public static double ToNumberX(LuaState L, int idx, ref int isnum)
        {
            return LuaNative.lua_tonumberx(L, idx, ref isnum);
        }

        /// <summary>
        /// Converts the value at the given index to a generic C pointer (void*). The value can be a userdata, a table, a thread, or a function; otherwise, lua_topointer returns NULL. Different objects will give different pointers. There is no way to convert the pointer back to its original value. Typically this function is used only for hashing and debug information. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static IntPtr ToPointer(LuaState L, int idx)
        {
            return LuaNative.lua_topointer(L, idx);
        }

        /// <summary>
        /// Equivalent to lua_tolstring with len equal to NULL. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static string ToString(LuaState L, int idx)
        {
            return LuaNative.lua_tostring(L, idx);
        }

        /// <summary>
        /// Converts the value at the given index to a Lua thread (represented as lua_State*). This value must be a thread; otherwise, the function returns NULL. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static LuaState ToThread(LuaState L, int idx)
        {
            return LuaNative.lua_tothread(L, idx);
        }

        /// <summary>
        /// If the value at the given index is a full userdata, returns its block address. If the value is a light userdata, returns its pointer. Otherwise, returns NULL. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static IntPtr ToUserData(LuaState L, int idx)
        {
            return LuaNative.lua_touserdata(L, idx);
        }

        /// <summary>
        /// Creates and pushes a traceback of the stack L1. If msg is not NULL it is appended at the beginning of the traceback. The level parameter tells at which level to start the traceback. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="L1"></param>
        /// <param name="msg"></param>
        /// <param name="level"></param>
        public static void TraceBack(LuaState L, LuaState L1, string msg, int level)
        {
            LuaNative.luaL_traceback(L, L1, msg, level);
        }

        /// <summary>
        /// Returns the type of the value in the given valid index, or LUA_TNONE for a non-valid (but acceptable) index. The types returned by lua_type are coded by the following constants defined in lua.h: LUA_TNIL (0), LUA_TNUMBER, LUA_TBOOLEAN, LUA_TSTRING, LUA_TTABLE, LUA_TFUNCTION, LUA_TUSERDATA, LUA_TTHREAD, and LUA_TLIGHTUSERDATA. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static LuaType Type(LuaState L, int idx)
        {
            return (LuaType)LuaNative.lua_type(L, idx);
        }

        /// <summary>
        /// Generates an error with a message like the following: location: bad argument narg to 'func' (tname expected, got rt) where location is produced by luaL_where, func is the name of the current function, and rt is the type name of the actual argument. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <param name="tname"></param>
        /// <returns></returns>
        public static int TypeError(LuaState L, int narg, string tname)
        {
            return LuaNative.luaL_typerror(L, narg, tname);
        }

        /// <summary>
        /// Returns the name of the type encoded by the value tp, which must be one the values returned by lua_type. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static string TypeName(LuaState L, LuaType tp)
        {
            return LuaNative.lua_typename_(L, (int)tp);
        }

        /// <summary>
        /// Releases reference ref from the table at index t (see luaL_ref). The entry is removed from the table, so that the referred object can be collected. The reference ref is also freed to be used again. If ref is LUA_NOREF or LUA_REFNIL, luaL_unref does nothing. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="t"></param>
        /// <param name="_ref"></param>
        public static void UnRef(LuaState L, int t, int _ref)
        {
            LuaNative.luaL_unref(L, t, _ref);
        }

        /// <summary>
        /// Returns a unique identifier for the upvalue numbered n from the closure at index funcindex. These unique identifiers allow a program to check whether different closures share upvalues. Lua closures that share an upvalue (that is, that access a same external local variable) will return identical ids for those upvalue indices. Parameters funcindex and n are as in function lua_getupvalue, but n cannot be greater than the number of upvalues. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IntPtr UpValueId(LuaState L, int idx, int n)
        {
            return LuaNative.lua_upvalueid(L, idx, n);
        }

        /// <summary>
        /// Returns the pseudo-index that represents the i-th upvalue of the running function (see §4.4). 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int UpValueIndex(int i)
        {
            return LuaNative.lua_upvalueindex(i);
        }

        /// <summary>
        /// Make the n1-th upvalue of the Lua closure at index funcindex1 refer to the n2-th upvalue of the Lua closure at index funcindex2. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx1"></param>
        /// <param name="n1"></param>
        /// <param name="idx2"></param>
        /// <param name="n2"></param>
        public static void UpValueJoin(LuaState L, int idx1, int n1, int idx2, int n2)
        {
            LuaNative.lua_upvaluejoin(L, idx1, n1, idx2, n2);
        }

        /// <summary>
        /// Returns the address of the version number (a C static variable) stored in the Lua core. When called with a valid lua_State, returns the address of the version used to create that state. When called with NULL, returns the address of the version running the call. 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static double Version(LuaState L)
        {
            return LuaNative.lua_version_(L);
        }

        /// <summary>
        /// Pushes onto the stack a string identifying the current position of the control at level lvl in the call stack. Typically this string has the following format: chunkname:currentline: Level 0 is the running function, level 1 is the function that called the running function, etc. This function is used to build a prefix for error messages. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="lvl"></param>
        public static void Where(LuaState L, int lvl)
        {
            LuaNative.luaL_where(L, lvl);
        }

        /// <summary>
        /// Exchange values between different threads of the same state. This function pops n values from the stack from, and pushes them onto the stack to. 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="n"></param>
        public static void XMove(LuaState from, LuaState to, int n)
        {
            LuaNative.lua_xmove(from, to, n);
        }

        /// <summary>
        /// This function is equivalent to lua_yieldk, but it has no continuation. Therefore, when the thread resumes, it continues the function that called the function calling lua_yield. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nresults"></param>
        /// <returns></returns>
        public static int Yield(LuaState L, int nresults)
        {
            return LuaNative.lua_yield(L, nresults);
        }
    }
}