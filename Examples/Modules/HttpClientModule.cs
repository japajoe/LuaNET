using System.Net.Http;
using LuaJITSharp;

namespace LuaJITExample
{
    public static class HttpClientModule
    {
        private static readonly string modulePath = "Modules/httpclient.lua";
        private static readonly HttpClient client = new HttpClient();

        private static LuaFunction httpclientGet;

        public static void Register(LuaState L)
        {
            if (Lua.DoFile(L, modulePath) == 0)
            {
                httpclientGet = Get;

                Lua.Register(L, "httpclientGet", httpclientGet);
            }
        }

        private static int Get(LuaState L)
        {
            if(LuaHelper.GetArgumentCount(L) != 1)
                return -1;

            if(!LuaHelper.CheckTypes(L, LuaType.String))
                return -1;

            string url = LuaHelper.PopString(L);            
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = client.Send(request);
            string message = string.Empty;

            using(var stream = response.Content.ReadAsStream())
            {                
                byte[] buffer = new byte[4096];
                int bytesRead = 0;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    message += System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
            }

            Lua.PushString(L, message);

            return 1;
        }
    }
}
