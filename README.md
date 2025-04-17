# AzureOpenAI-MCPClient
A MCP Client implementation with _Azure OpenAI_

This MCP Client was tested with [this](https://github.com/RodrigoPAml/MCP-SqlServer) MCP Server for integration with Sql-Server . 

It only supports tools but integrating prompts and resources should be easy with that.

The solution contains two projects:

## Client

The MCP Client implementation that also runs a console chat with the Azure LLM and calls the configured MCP Server

To use it go to ```Program.cs``` and fill with the necessary configuration (Azure and MCP Server) and run it.

![image](https://github.com/user-attachments/assets/ada03773-83fa-4921-bb20-a36f1291c44b)

You will run a chat integrated with a MCP Server using _stdio_.

![image](https://github.com/user-attachments/assets/ef662d1a-e3ba-4d47-8d54-b4df38ed4894)

The console will ask your permission to run the tools requested by the LLM

![image](https://github.com/user-attachments/assets/e36ca2a6-3b42-418c-ac8a-5b07e709d355)

## GUI 

A Windows Form Chat that can be configured directly in the UI. It does the same as the Client project but more user friendly.

First fill the configuration for Azure OpenAI and optionally the MCP Server config and click ```Apply Configs```

![image](https://github.com/user-attachments/assets/36d410e4-1b40-48c8-ad95-09f7d9fd0394)

Write a message then click ```Send```. 

If you you want to reset the chat conversation click ```Reset```.  

To change configs click again on ```Apply Configs```

![image](https://github.com/user-attachments/assets/45826418-8053-43ff-9c45-670185c1a436)

Ask for a tool and it will ask your permission

![image](https://github.com/user-attachments/assets/e8ba58ca-344a-494d-8828-95610f372b05)

The results are then displayed on the chat

![image](https://github.com/user-attachments/assets/349c952b-0ee0-4c7e-a520-d3a350084b20)

Lets try a query to list users

![image](https://github.com/user-attachments/assets/6a38f8e0-a7d6-42e2-96bd-7fa9286764a3)

The results:

![image](https://github.com/user-attachments/assets/639269f5-6e07-4310-a1c7-054baa193ba0)


