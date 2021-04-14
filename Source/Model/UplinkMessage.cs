

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RaaLabs.Edge.Connectors.Lora.Model
{
    /// <summary>
    /// </summary>

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class UplinkMessage
    {
        public string FrmPayload { get; set; }
        public Dictionary<string, dynamic> DecodedPayload { get; set; }
        public string ReceivedAt { get; set; }
    }
}
