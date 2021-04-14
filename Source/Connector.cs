// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;
using MQTTnet.Server;
using RaaLabs.Edge.Modules.EventHandling;
using Serilog;

namespace RaaLabs.Edge.Connectors.Lora
{
    /// <summary>
    /// Represents an implementation for <see cref="IProduceEvent"/>
    /// </summary>
    public class Connector : IRunAsync, IProduceEvent<Events.MqttEventReceived>
    {
        /// <inheritdoc/>

        public event EventEmitter<Events.MqttEventReceived> MqttEventReceived;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="Connector"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> for logging</param>
        public Connector(ILogger logger)
        {
            _logger = logger;
            _logger.Information($"Will expose MQTT");
        }

        public async Task Run()
        {
            _logger.Information("Starting MQTT Broker");
            var optionsBuilder = new MqttServerOptionsBuilder()
                .WithDefaultEndpointPort(1883).WithConnectionValidator(_ => _.ReasonCode = MqttConnectReasonCode.Success);
            var options = optionsBuilder.Build();
            var server = new MqttFactory().CreateMqttServer();
            server.ClientConnectedHandler = new MqttServerClientConnectedHandlerDelegate(e => { _logger.Information($"Client {e.ClientId} connected"); });
            server.ClientDisconnectedHandler = new MqttServerClientDisconnectedHandlerDelegate(e => { _logger.Information($"Client {e.ClientId} connected"); });
            server.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(e => { MessageReceived(e); });
            await server.StartAsync(options);
        }

        void MessageReceived(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            _logger.Information($"Received MQTT Message on topic '{eventArgs.ApplicationMessage.Topic}'");
            var mqttPayload = eventArgs.ApplicationMessage.Payload;
            MqttEventReceived(mqttPayload);
        }
    }
}