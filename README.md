# Connector.Lora
[![.NET 5.0](https://github.com/RaaLabs/Connectors.Lora/actions/workflows/dotnet-core.yml/badge.svg)](https://github.com/RaaLabs/Connectors.Lora/actions/workflows/dotnet-core.yml)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=RaaLabs_Connectors.Lora&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=RaaLabs_Connectors.Lora)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=RaaLabs_Connectors.Lora&metric=coverage)](https://sonarcloud.io/dashboard?id=RaaLabs_Connectors.Lora)

[![.NET 5.0](https://github.com/RaaLabs/Connectors.Lora/actions/workflows/dotnet-core.yml/badge.svg)](https://github.com/RaaLabs/Connectors.Lora/actions/workflows/dotnet-core.yml)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=RaaLabs_Connectors.Lora&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=RaaLabs_Connectors.Lora)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=RaaLabs_Connectors.Lora&metric=coverage)](https://sonarcloud.io/dashboard?id=RaaLabs_Connectors.Lora)


This document describes the Connectors.Lora module for RaaLabs Edge.

## What does it do?

Connector.Lora receives MQTT topics from the TTI stack on a serialized JSON format. Deserialized payloads contains a raw data string on HEX format (`frm_payload`) and a decoded payload on human readable format (`decoded_payload`). In short, relevant attributes in the payload are

```json
{
  "end_device_ids": {
    "device_id": "<>",
    "application_ids": {
      "application_id": "<appId>"
    },
    "dev_eui": "<devEui>",
    "join_eui": "<>",
    "dev_addr": "<>"
  },
  "received_at": "2021-04-20T07:23:08.516079327Z",
  "uplink_message": {
    "frm_payload": "+I0qIwPQXwMAANE=",
    "decoded_payload": {
      "batV": 5.225
    }
  }
}
```

The connector are producing one event per attribute in `decoded_payload` on the format defined as in SendDataPoint

```json
{
  "source": "Lora",
  "tag": "<dev_eui>/<decoded_payload.Key>",
  "timestamp": "<received_at>",
  "value": "<decoded_payload.Value>"
}
```

The connector are producing events of type [OutputName("output")] and should be routed to [IdentityMapper](https://github.com/RaaLabs/IdentityMapper).

## Configuration

The module is configured using a JSON file (`connector.json`) XXX like the one below. If mqttClient is set to _true_, specify the ip and port to connect to the broker. If mqttClient is set to _false_ it will run as broker.

```json
{
  "ip": "127.0.0.1",
  "port": 1883,
  "mqttclient": true
}
```

## IoT Edge Deployment

### $edgeAgent

In your `deployment.json` file, you will need to add the module. For more details on modules in IoT Edge, go [here](https://docs.microsoft.com/en-us/azure/iot-edge/module-composition).

The module has persistent state and it is assuming that this is in the `data` folder relative to where the binary is running.
Since this is running in a containerized environment, the state is not persistent between runs. To get this state persistent, you'll
need to configure the deployment to mount a folder on the host into the data folder.

In your `deployment.json` file where you added the module, inside the `HostConfig` property, you should add the
volume binding.

```json
"Binds": [
    "<mount-path>:/app/data"
]
```

```json
{
  "modulesContent": {
    "$edgeAgent": {
      "properties.desired.modules.Lora": {
        "settings": {
          "image": "<repo-name>/connectors-lora:<tag>",
          "createOptions": "{\"HostConfig\":{\"Binds\":[\"<mount-path>:/app/data\"]}}"
        },
        "type": "docker",
        "version": "1.0",
        "status": "running",
        "restartPolicy": "always"
      }
    }
  }
}
```

For production setup, the bind mount can be replaced by a docker volume.

### $edgeHub

The routes in edgeHub can be specified like the example below.

```json
{
  "$edgeHub": {
    "properties.desired.routes.LoraToIdentityMapper": "FROM /messages/modules/Lora/outputs/output INTO BrokeredEndpoint(\"/modules/IdentityMapper/inputs/events\")"
  }
}
```
