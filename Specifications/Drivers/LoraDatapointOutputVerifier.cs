// Copyright (c) RaaLabs. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using RaaLabs.Edge.Connectors.Lora.Events;
using TechTalk.SpecFlow;
using FluentAssertions;


namespace RaaLabs.Edge.Connectors.Lora.Specs.Drivers
{
    class LoraDatapointOutputVerifier : IProducedEventVerifier<LoraDatapointOutput>
    {
        public void VerifyFromTableRow(LoraDatapointOutput @event, TableRow row)
        { 
            dynamic actualValue = @event.Value;
            var expectedValue = ParseValue(row);
            @event.Source.Should().Be("Lora");
            @event.Tag.Should().Be(row["Tag"]);

            if(expectedValue is double && actualValue is double)
            {
                double expectedDoubleValue = expectedValue;
                double actualDoubleValue = actualValue;
                actualDoubleValue.Should().BeApproximately(expectedDoubleValue, 0.0001f);
            } 
            else if (expectedValue is bool && actualValue is bool)
            {
                bool expectedBoolValue = expectedValue;
                bool actualBoolValue = actualValue;
                actualBoolValue.Should().Be(expectedBoolValue);
            }
            else if(expectedValue is string && actualValue is string)
            {
                string expectedStringValue = expectedValue;
                string actualStringValue = actualValue;
                actualStringValue.Should().Be(expectedStringValue);
            }     
        }
        private dynamic ParseValue(TableRow tableRow)
        {
            return tableRow["Datatype"] switch
            {
                "double" => double.Parse(tableRow["Value"]), 
                "bool" => bool.Parse(tableRow["Value"]),
                "string" => tableRow["Value"],
                _ => null
            };
        }
    }
}

