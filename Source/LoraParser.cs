/*---------------------------------------------------------------------------------------------
 *  Copyright (c) RaaLabs. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using RaaLabs.Edge.Connectors.Lora.Model;

namespace RaaLabs.Edge.Connectors.Lora
{
    /// <summary>
    /// Represents an implementation of <see cref="ILoraParser"/>
    /// </summary>
    public class LoraParser : ILoraParser
    {
        
        /// <inheritdoc/>
        public bool CanParse(JObject payload)
        {
            // TODO
            return true;
        }

        /// <inheritdoc/>
        public string GetApplicationIdFor(JObject payload)
        {
            return (string)payload["end_device_ids"]["application_ids"]["application_id"];
        }
        /// <inheritdoc/>
        public string GetDeviceIdFor(JObject payload)
        {
            return (string)payload["end_device_ids"]["device_id"];
        }

        /// <inheritdoc/>
        public long GetTimestampFor(LoraMessage message)
        {
            string time = message.UplinkMessage.ReceivedAt;
            long epochTimestamp = DateTimeOffset.Parse(time).ToUnixTimeMilliseconds();
            return epochTimestamp;
        }

        /// <inheritdoc/>
        public JToken GetDecodedPayloadFor(JObject payload)
        {
            // TODO
            var encodedPayload = payload["uplink_message"]["decoded_payload"];
            return encodedPayload;
        }

    }
}