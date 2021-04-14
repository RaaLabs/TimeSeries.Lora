/*---------------------------------------------------------------------------------------------
 *  Copyright (c) RaaLabs. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RaaLabs.Edge.Connectors.Lora.Model;

namespace RaaLabs.Edge.Connectors.Lora
{
    /// <summary>
    /// Defines the parser of payloads
    /// </summary>
    public interface ILoraParser
    {
        /// <summary>
        /// Check if payload can be parsed
        /// </summary>
        /// <param name="payload">payload to check</param>
        /// <returns>True if it can be parsed, false if not</returns>
        bool CanParse(JObject payload);

        /// <summary>
        /// Get the unique payload identifier for the payload
        /// </summary>
        /// <param name="payload">The payload to get for</param>
        /// <returns>Unique identifier for the payload</returns>
        string GetApplicationIdFor(JObject payload);

        /// <summary>
        /// Get the device identifier for the payload
        /// </summary>
        /// <param name="payload">The payload to get for</param>
        /// <returns>Unique identifier for the payload</returns>
        string GetDeviceIdFor(JObject payload);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        long GetTimestampFor(LoraMessage payload);

        /// <summary>
        /// Parse a parseable payload into its target object
        /// </summary>
        /// <param name="payload">payload to parse</param>
        /// <returns>All the results parsed</returns>
        JToken GetDecodedPayloadFor(JObject payload);

    }
}