

using System.Collections.Generic;

namespace RaaLabs.Edge.Connectors.Lora.Model
{
    /// <summary>
    /// </summary>
    public class UplinkMessage
    {

        public string FrmPayload { get; set; }
        public Dictionary<string, dynamic> DecodedPayload { get; set; }
        public string ReceivedAt { get; set; }

    }
}
