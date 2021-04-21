using TechTalk.SpecFlow;
using RaaLabs.Edge.Testing;

namespace RaaLabs.Edge.Connectors.Lora.Specs.Drivers
{

    [Binding]
    public sealed class TypeMapperProvider
    {
        private readonly TypeMapping _typeMapping;

        public TypeMapperProvider(TypeMapping typeMapping)
        {
            _typeMapping = typeMapping;
        }

        [BeforeScenario]
        public void SetupTypes()
        {
            _typeMapping.Add("ParserHandler", typeof(ParserHandler));
            _typeMapping.Add("MqttEventReceived", typeof(Events.MqttEventReceived));
            _typeMapping.Add("LoraDatapointOutput", typeof(Events.LoraDatapointOutput));
        }
    }
}