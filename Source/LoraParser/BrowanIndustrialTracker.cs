/*---------------------------------------------------------------------------------------------
 *  Copyright (c) RaaLabs. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

/* 
INPUT: "DPs8AAAAAAAAAAA="
OUTPUT:
decoded_payload" : {
      "bat_percentage" : 100,
      "battery_value" : 3.6,
      "latitude" : 0,
      "longitude" : 0,
      "status" : 12,
      "temperature" : 28
    }
*/

namespace RaaLabs.TimeSeries.Lora.LoraParser
{
    public class BrowanIndustrialTracker : ILoraParser
    {
        public string ApplicationId => "BrowanIndustrialTracker";
        public IEnumerable<TagWithData> Parse(string[] values)
        {
          //TODO
        }
    }
}
