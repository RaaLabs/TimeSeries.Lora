// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RaaLabs.Edge.Connectors.Lora.Model
{

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ApplicationIds
    {
        /// <summary>
        /// Define application id
        /// </summary>
        public string ApplicationId { get; set; }
    }
}
