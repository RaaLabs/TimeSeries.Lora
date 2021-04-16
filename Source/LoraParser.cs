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
        public bool CanParse(LoraMessage message)
        {
            var validPayload = message.UplinkMessage.DecodedPayload != null ? true : false;
            if (!validPayload)
            {
                throw new MissingDecodedPayloadException(message.EndDeviceIds.DevEui);
            }
            return validPayload;
        }
        

        /// <inheritdoc/>
        public string GetApplicationIdFor(LoraMessage message)
        {
            return message.EndDeviceIds.ApplicationIds.ApplicationId;
        }
        /// <inheritdoc/>
        public string GetDeviceIdFor(LoraMessage message)
        {
            return message.EndDeviceIds.DevEui;
            //return (string)message["end_device_ids"]["device_id"];
        }

        /// <inheritdoc/>
        public long GetTimestampFor(LoraMessage message) 
        {
            string time = message.UplinkMessage.ReceivedAt;
            long epochTimestamp = DateTimeOffset.Parse(time).ToUnixTimeMilliseconds();
            return epochTimestamp;
            
        }

        /// <inheritdoc/>
        public Dictionary<string, dynamic> GetDecodedPayloadFor(LoraMessage message)
        {
            // TODO
            
            return message.UplinkMessage.DecodedPayload;
        
        }
        public string GetRawPayload(LoraMessage message)
        {
            return message.UplinkMessage.FrmPayload;
        }

        

    }
}