using Newtonsoft.Json;

namespace AI_Bot
{
    public struct configJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("prefix")]
        public string Prefix { get; private set; }

    }
}
