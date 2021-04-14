

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RaaLabs.Edge.Connectors.Lora.Model
{
    /// <summary>
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ApplicationIds
    {
        string ApplicationId { get; set; }
    }
}
