// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RaaLabs.Edge.Connectors.Lora.Model
{
    /// <summary>
    /// Defines Lora message 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class LoraMessage
    {
        /// <summary>
        /// Define relevant device ids  
        /// </summary>
        public EndDeviceIds EndDeviceIds { get; set; }
        /// <summary>
        /// Define Uplink message
        /// </summary>
        public UplinkMessage UplinkMessage { get; set; }
    }
}
