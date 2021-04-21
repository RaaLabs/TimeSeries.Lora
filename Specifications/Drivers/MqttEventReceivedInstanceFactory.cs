// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using RaaLabs.Edge.Connectors.Lora.Events;
using TechTalk.SpecFlow;
using System.Linq;

namespace RaaLabs.Edge.Connectors.Lora.Specs.Drivers
{
    class MqttEventReceivedInstanceFactory : IEventInstanceFactory<MqttEventReceived>
    {
        public MqttEventReceived FromTableRow(TableRow row)
        {
            var payload = row["Payload"].Split(" ").Select(b => byte.Parse(b)).ToArray();
            return new MqttEventReceived(payload);
        }
    }
}
