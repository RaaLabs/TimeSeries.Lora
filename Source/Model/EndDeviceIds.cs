// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RaaLabs.Edge.Connectors.Lora.Model
{
    /// <summary>
    /// Define relevant device ids
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class EndDeviceIds
    {

        /// <summary> DeviceId is the given id upon creation/claiming of device in the TTI stack. </summary>
        public string DeviceId { get; set; }

        /// <summary> ApplicationIds contain the given id upon creation of an application in the TTI stack.  </summary>
        public ApplicationIds ApplicationIds { get; set; }

        /// <summary> DevEui is equvalent to the serial number of the Lora device and is globaly unique. </summary>
        public string DevEui { get; set; }
        
        /// <summary> JoinEui is the unique ID of application server. This is the destintion of the messages sent by the device. </summary>
        public string JoinEui { get; set; }
        public string DevAddr { get; set; }

    }
}
