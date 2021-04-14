

namespace RaaLabs.Edge.Connectors.Lora.Model
{
    /// <summary>
    /// </summary>
    public class EndDeviceIds
    {

        public string DeviceId { get; set; }
        public ApplicationIds ApplicationIds { get; set; }
        public string DevEui { get; set; }
        public string JoinEui { get; set; }
        public string DevAddr { get; set; }

    }
}
