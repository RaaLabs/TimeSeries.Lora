/*---------------------------------------------------------------------------------------------
 *  Copyright (c) RaaLabs. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using RaaLabs.Edge.Connectors.Lora.Model;
using Serilog;

namespace RaaLabs.Edge.Connectors.Lora
{
    /// <summary>
    /// Represents an implementation of <see cref="ILoraParser"/>
    /// </summary>
    public class LoraParser : ILoraParser
    {
        private readonly ILogger _logger;

        public LoraParser(ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public bool CanParse(LoraMessage payload)
        {
            var validPayload = payload.UplinkMessage.DecodedPayload != null;
            if (!validPayload)
            {
                var devEui = GetDeviceIdFor(payload);
                _logger.Warning($"'{devEui}': does not contain decoded payload");
            }
            return validPayload;
        }


        /// <inheritdoc/>
        public string GetApplicationIdFor(LoraMessage payload) => payload.EndDeviceIds.ApplicationIds.ApplicationId;
        /// <inheritdoc/>
        public string GetDeviceIdFor(LoraMessage payload) => payload.EndDeviceIds.DevEui;

        /// <inheritdoc/>
        public long GetTimestampFor(LoraMessage payload) 
        {
            string time = payload.UplinkMessage.ReceivedAt;
            long epochTimestamp = DateTimeOffset.Parse(time).ToUnixTimeMilliseconds();
            return epochTimestamp;
            
        }

        /// <inheritdoc/>
        public Dictionary<string, dynamic> GetDecodedPayloadFor(LoraMessage payload) => payload.UplinkMessage.DecodedPayload;



    }
}