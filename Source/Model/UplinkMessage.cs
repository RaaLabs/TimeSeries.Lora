// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RaaLabs.Edge.Connectors.Lora.Model
{
    /// <summary>
    /// Define payload message/uplink message as class 
    /// </summary>

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class UplinkMessage
    {
        public string FrmPayload { get; set; }
        public Dictionary<string, dynamic> DecodedPayload { get; set; }
        public string ReceivedAt { get; set; }
    }
}