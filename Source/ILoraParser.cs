/*---------------------------------------------------------------------------------------------
 *  Copyright (c) RaaLabs. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace RaaLabs.TimeSeries.Lora
{
    public interface ILoraParser
    {
        /// <summary>
        /// Get the Lora application_id
        /// </summary>
        string ApplicationId { get; }
        
        /// <summary>
        /// Parse the encoded payload and return decoded payloads 
        /// </summary>
        /// <param name="values">The values to parse</param>
        /// <returns>Timeseries events</returns>
        IEnumerable<TagWithData> Parse(string[] values);

    }
}