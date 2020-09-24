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
        public IEnumerable<TagWithData> Parse(string encodedString)
        { 
          //string encodedString = "CAE2TUWEA/1qVuA=";//DPs8AAAAAAAAAAA=";
          byte[] values = Convert.FromBase64String(encodedString);
          var status = values[0];
          var battery = (float)((values[1] & 0x0f) + 25) / 10;
          var bat_percentage = (float)100 * ((values[1] >> 4) / 15);
          var _lat = (float)(values[6] << 24) + (values[5] << 16) + (values[4] << 8) + (values[3]);
          //Console.WriteLine("lat_type {0}",_lat.GetType());
          float latitude;
          float longitude;
          
          if (_lat > 134217727) {
                latitude = (_lat - 268435456) / 1000000;
          }
          else {
              latitude = _lat / 1000000;
          }
          if (((values[10]) & 0xf0) == 0x10) {
              longitude = (float)((((values[10]) << 24) + (values[9] << 16) + (values[8] << 8) + values[7]) - 536870912) / 1000000;
          }
          else {
              longitude = (float)(((values[10] & 0x0f) << 24) + (values[9] << 16) + (values[8] << 8) + values[7]) / 1000000;
          }
          /*callback(new TagDataPoint<double>{
              status = status,
              latitude = latitude,
              longitude = longitude,
              temperature = temperature,
              battery_value = battery,
              bat_percentage = bat_percentage
          });*/
        }
    }
}
