// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;
using RaaLabs.Edge.Modules.EventHandling;
using RaaLabs.Edge.Modules.EdgeHub;
using RaaLabs.Edge.Modules.Configuration;

namespace RaaLabs.Edge.Connectors.Lora
{
    [ExcludeFromCodeCoverage]
    static class Program
    {
        static void Main()
        {
            var application = new ApplicationBuilder()
                .WithModule<EventHandling>()
                .WithModule<EdgeHub>()
                .WithModule<Configuration>()
                .WithTask<Connector>()
                .WithHandler<ParserHandler>()
                .WithType<LoraParser>()
                .Build();

            application.Run().Wait();
        }
    }
}
