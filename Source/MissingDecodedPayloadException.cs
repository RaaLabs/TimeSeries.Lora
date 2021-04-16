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
    /// Exception that gets thrown if Lora message is missing decoded payload
    /// </summary>
    public class MissingDecodedPayloadException : Exception
    {
        public MissingDecodedPayloadException(string devEui) : base($"'{devEui}': does not contain decoded payload")
        {
        
        }
    }
}