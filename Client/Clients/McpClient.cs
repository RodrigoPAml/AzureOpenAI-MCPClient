using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
using OpenAI.Chat;
using System.Text.Json;

namespace Client.Clients
{
    /// <summary>
    /// MCP Client that supports STDIO 
    /// But can be extendend easy for SSE
    /// </summary>
    public class McpClient
    {
        private IMcpClient _client;
        private StdioClientTransport _transport;

        public McpClient(string name, string command, IList<string> arguments)
        {
            _transport = new StdioClientTransport(new()
            {
                Name = name,
                Command = command,
                Arguments = arguments
            });
        }

        public async Task Connect()
        {
            _client = await McpClientFactory.CreateAsync(_transport);
        }

        public async Task<string> CallTool(string name, BinaryData args)
        {
            var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(
                args,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
                }
            );

            var result = await _client.CallToolAsync(name, dict);

            return result.Content.First(c => c.Type == "text").Text;
        }

        public async Task<List<ChatTool>> GetToolsForAzure()
        {
            var tools = new List<ChatTool>();  

            foreach (var tool in await _client.ListToolsAsync())
            {
                var azureTool = ChatTool.CreateFunctionTool(
                    tool.Name,
                    tool.Description,
                    BinaryData.FromString(tool.JsonSchema.ToString())
                );

                tools.Add(azureTool);
            }

            return tools;
        }
    }
}
