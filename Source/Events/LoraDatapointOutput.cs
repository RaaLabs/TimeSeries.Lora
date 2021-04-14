// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using RaaLabs.Edge.Modules.EdgeHub;

namespace RaaLabs.Edge.Connectors.Lora.Events
{
    [OutputName("output")]
    public class LoraDatapointOutput : IEdgeHubOutgoingEvent
    {

        public string source { get; set; }

        public string tag { get; set; }

        public dynamic value { get; set; }

        public long timestamp { get; set; }
    }
}
