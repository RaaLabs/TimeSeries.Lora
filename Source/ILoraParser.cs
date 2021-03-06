// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
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
        bool CanParse(LoraMessage payload);

        /// <summary>
        /// Get the unique payload identifier for the payload
        /// </summary>
        /// <param name="payload">The payload to get for</param>
        /// <returns>Unique identifier for the payload</returns>
        string GetApplicationIdFor(LoraMessage payload);

        /// <summary>
        /// Get the device identifier for the payload
        /// </summary>
        /// <param name="payload">The payload to get for</param>
        /// <returns>Unique identifier for the payload</returns>
        string GetDeviceIdFor(LoraMessage payload);
        
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
        Dictionary<string,dynamic> GetDecodedPayloadFor(LoraMessage payload);

    }
}