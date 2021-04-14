

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RaaLabs.Edge.Connectors.Lora.Model
{
    /// <summary>
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class LoraMessage
    {
        public EndDeviceIds EndDeviceIds {get; set;}
        public UplinkMessage UplinkMessage {get; set;}
    }
}
