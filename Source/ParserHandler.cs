// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.IO.Compression;
using Serilog;
using RaaLabs.Edge.Connectors.Lora.Events;
using RaaLabs.Edge.Modules.EventHandling;
using Newtonsoft.Json.Linq;
using System.Text;
using RaaLabs.Edge.Connectors.Lora.Model;
using Newtonsoft.Json;

namespace RaaLabs.Edge.Connectors.Lora
{
    /// <summary>
    /// Parser handler
    /// </summary>
    public class ParserHandler : IConsumeEvent<Events.MqttEventReceived>, IProduceEvent<Events.LoraDatapointOutput>
    {
        public event EventEmitter<Events.LoraDatapointOutput> SendDataPoint;
        readonly ILogger _logger;
        readonly ILoraParser _parser;

        /// <summary>
        /// Initializes a new instance of <see cref="ILogger"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> to use for logging</param>
        /// <param name="parser"><see cref="ILoraParser"/> used for parsing of Lora payloads</param>
        public ParserHandler(ILogger logger, ILoraParser parser)
        {
            _logger = logger;
            _parser = parser;
        }

        /// <inheritdoc/>
        public void Handle(Events.MqttEventReceived @event)
        {
            try
            {
                var stringPayload = Encoding.UTF8.GetString(@event.Payload);
                var payload = JsonConvert.DeserializeObject<LoraMessage>(stringPayload);

                if (_parser.CanParse(payload))
                {
                    var decodedPayload = _parser.GetDecodedPayloadFor(payload);
                    var timestamp = _parser.GetTimestampFor(payload);
                    var devEui = _parser.GetDeviceIdFor(payload);

                    foreach (var dataPoint in decodedPayload)
                    {
                        var outputDatapoint = new LoraDatapointOutput
                        {
                            source = "Lora",
                            tag = devEui + "/" + dataPoint.Key,
                            timestamp = timestamp,
                            value = dataPoint.Value
                        };
                        SendDataPoint(outputDatapoint);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while parsing payload");
            }
        }
    }
}