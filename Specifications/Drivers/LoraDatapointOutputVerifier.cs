using RaaLabs.Edge.Connectors.Lora.Events;
using TechTalk.SpecFlow;
using FluentAssertions;
using System.Globalization;


namespace RaaLabs.Edge.Connectors.Lora.Specs.Drivers
{
    class LoraDatapointOutputVerifier : IProducedEventVerifier<LoraDatapointOutput>
    {
        public void VerifyFromTableRow(LoraDatapointOutput @event, TableRow row)
        { 
            dynamic actualValue = @event.value;
            var expectedValue = ParseValue(row);
            @event.source.Should().Be("Lora");
            @event.tag.Should().Be(row["Tag"]);

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

