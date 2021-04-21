// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RaaLabs.Edge.Connectors.Lora.Model
{
    /// <summary>
    /// Define payload message/uplink message
    /// </summary>

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class UplinkMessage
    {
        /// <summary>
        /// Raw, endocoded payload
        /// </summary>
        public string FrmPayload { get; set; }
        /// <summary>
        /// Human readable, decoded payload
        /// </summary>
        public Dictionary<string, dynamic> DecodedPayload { get; set; }
        /// <summary>
        /// Timestamp of event 
        /// </summary>
        public string ReceivedAt { get; set; }
    }
}
