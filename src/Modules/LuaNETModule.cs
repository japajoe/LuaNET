namespace LuaNET.Modules
{
    public class LuaNETModule : LuaModule
    {
        public override void Initialize(LuaState L)
        {
            RegisterMethod(L, "luanet_getFunctionPointer", GetFunctionPointer);

            string source = @"local ffi = require('ffi')            
local luanet = {}

function luanet.findMethod(name, signature)
    local address = luanet_getFunctionPointer(name)
    if address == nil then
        return nil
    end

    return ffi.cast(signature, tonumber(address))
end

return luanet";

            LuaModuleLoader.RegisterFromString(L, "luanet", source);
        }

        private static int GetFunctionPointer(LuaState L)
        {
            if(LuaHelper.GetArgumentCount(L) != 1)
            {
                Lua.SetTop(L, -1);
                return -1;
            }

            if(!LuaHelper.CheckTypes(L, LuaType.String))
            {
                Lua.SetTop(L, -1);
                return -1;
            }

            string name = LuaHelper.PopString(L);

            if(!delegates.ContainsKey(name))
            {
                Lua.PushNil(L);
                return 1;
            }

            var info = delegates[name];
            Lua.PushInteger(L, info.pointer.ToInt64());

            return 1;
        }
    }
}