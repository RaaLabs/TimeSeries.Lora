function Decoder(bytes, f_port) {
    var status = ((bytes[0]))
    var battery = (((bytes[1] & 0x0f) + 25) / 10); // considering lower nibble
    var bat_percentage = 100 * ((bytes[1] >> 4) / 15); // considering higher nibble
    var temperature = ((bytes[2] & 0x7f) - 32); // last bit is RFU
    var _lat = (bytes[6] << 24) + (bytes[5] << 16) + (bytes[4] << 8) + (bytes[3]);
    if (_lat > 134217727) {
        var latitude = (_lat - 268435456) / 1000000;
    }
    else {
        var latitude = _lat / 1000000;
    }
    if (((bytes[10]) & 0xf0) == 0x10) {
        var longitude = ((((bytes[10]) << 24) + (bytes[9] << 16) + (bytes[8] << 8) + bytes[7]) - 536870912) / 1000000;
    }
    else {
        var longitude = (((bytes[10] & 0x0f) << 24) + (bytes[9] << 16) + (bytes[8] << 8) + bytes[7]) / 1000000;
    }
    return {
        status: status,
        latitude: latitude,
        longitude: longitude,
        temperature: temperature,
        battery_value: battery,
        bat_percentage: bat_percentage
    };
}