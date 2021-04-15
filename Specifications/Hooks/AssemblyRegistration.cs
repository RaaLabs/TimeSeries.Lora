using RaaLabs.Edge.Testing;
using TechTalk.SpecFlow;
using BoDi;

namespace RaaLabs.Edge.Connectors.Lora.Specs.Drivers
{
    [Binding]
    class LoraParserProvider
    {
        private readonly IObjectContainer _container;

        public LoraParserProvider(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        private void ProvideLoraParser()
        {
            _container.RegisterTypeAs<LoraParser, ILoraParser>();
        }
    }
}