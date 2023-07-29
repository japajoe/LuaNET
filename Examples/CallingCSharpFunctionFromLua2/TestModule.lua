local ffi = require("ffi")
local luanet = require("luanet")

local library = {}
--Gets a function pointer to the registered C-Sharp function.
library.TestModuleWriteLine = luanet.findMethod("TestModuleWriteLine", "void (__cdecl*)(char*)")

local testmodule = {}

function testmodule.writeLine(message)
    if type(message) == "number" then
        message = tostring(message)
    end

    -- Converts the lua string into a C-string
    -- Lua owns this memory and will garbage collect it eventually
    local c_message = ffi.new("char[?]", #message + 1)
    ffi.copy(c_message, message)

    -- Calls the C-Sharp method
    library.TestModuleWriteLine(c_message)
end

return testmodule