local http = require("Modules/httpclient")

local response = http.get("https://www.google.com")

print(response)
