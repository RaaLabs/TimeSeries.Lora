// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using RaaLabs.Edge.Modules.EventHandling;

namespace RaaLabs.Edge.Connectors.Lora.Events
{
    public class MqttEventReceived : IEvent
    {
        public byte[] Payload { get; set; }

        public MqttEventReceived(byte[] payload)
        {
            Payload = payload;
        }
        public static implicit operator MqttEventReceived(byte[] payload) => new MqttEventReceived(payload);
    }
}
