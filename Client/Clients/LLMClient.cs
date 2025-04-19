using Azure.AI.OpenAI;
using Client.Utils;
using OpenAI.Chat;
using System.ClientModel;

namespace Client.Clients
{
    /// <summary>
    /// LLMClient
    /// </summary>
    public class LLMClient
    {
        /// <summary>
        /// Azure OpenAI Client
        /// </summary>
        private readonly ChatClient _client;

        /// <summary>
        /// MCP Client
        /// </summary>
        private McpClient _mcpClient;

        /// <summary>
        /// Chat historic
        /// </summary>
        private List<ChatMessage> _historic = new();

        /// <summary>
        /// Get the historic messages
        /// </summary>
        /// <returns></returns>
        public List<ChatMessage> GetHistoric() => _historic.ToList();

        /// <summary>
        /// Callback for chat messages
        /// </summary>
        private Action<ChatMessage> _callbackMsg;

        /// <summary>
        /// Callback to authorize tools
        /// </summary>
        private Func<string, string, bool> _callbackTool;

        public LLMClient(string endpoint, string key, string model)
        {
            var azureClient = new AzureOpenAIClient(
                new Uri(endpoint), 
                new ApiKeyCredential(key)
            );

            _client = azureClient.GetChatClient(model);
        }

        public void SetMcpClient(McpClient client)
        {
            _mcpClient = client;
        }

        public void ClearHistoric()
        {
            _historic.Clear(); 
        }

        public async Task SendMessage(string message)
        {
            var newMsg = new UserChatMessage(message);
            _historic.Add(newMsg);

            NotifyMessage(newMsg);

            var response = await _client.CompleteChatAsync(_historic, await GetOptions());
            await ProcessResponse(response);
        }

        private async Task ProcessResponse(ChatCompletion response)
        {
            switch (response.FinishReason)
            {
                case ChatFinishReason.Stop:
                    CompleteStopReason(response);
                    break;
                case ChatFinishReason.Length:
                    throw new Exception("Max token reached for the model in this request");
                case ChatFinishReason.ContentFilter:
                    throw new Exception("The content was omitted due to a filter policy");
                case ChatFinishReason.ToolCalls:
                    await CompleteToolCallsReason(response);
                    break;
                default:
                    throw new Exception($"Invalid Finish Reason: ${response.FinishReason}");
            }
        }

        private async Task CompleteToolCallsReason(ChatCompletion response)
        {
            if(_mcpClient == null)
                throw new Exception($"No MCP Client provided for tool calling");

            // Check if the assistant has provided a message with the ToolCall 
            if (response.Content.Any())
            {
                if (response.Role != ChatMessageRole.Assistant)
                    throw new Exception($"Expecting a message from assistant role but got {response.Role}");

                var msg = new AssistantChatMessage(response.Content.FirstOrDefault().Text);

                _historic.Add(msg);
                NotifyMessage(msg);
            }

            // Resolve tools
            foreach (var tool in response.ToolCalls)
            {
                var messageAssitent = new AssistantChatMessage($"Calling tool {tool.FunctionName} with args {tool.FunctionArguments} to answer your request");
                messageAssitent.ToolCalls.Add(tool);

                bool authorized = true;

                if (_callbackTool != null)
                    authorized = _callbackTool(tool.FunctionName, FormatJSON.FromBinaryData(tool.FunctionArguments));

                var result = "";
                if(!authorized)
                   result = $"Tool call for {tool.FunctionName} was not authorized by user";
                else 
                    result = await _mcpClient.CallTool(tool.FunctionName, tool.FunctionArguments);

                _historic.Add(messageAssitent);
                NotifyMessage(messageAssitent);

                var tooMsg = new ToolChatMessage(tool.Id, result);
                _historic.Add(tooMsg);
                NotifyMessage(tooMsg);
            }

            var withToolsResponse = await _client.CompleteChatAsync(_historic, await GetOptions());
            await ProcessResponse(withToolsResponse);
        }

        private void CompleteStopReason(ChatCompletion response)
        {
            if (response.Role != ChatMessageRole.Assistant)
                throw new Exception($"Expecting a message from assistant role but got {response.Role}");

            var text = response.Content.FirstOrDefault().Text;

            if (string.IsNullOrEmpty(text))
                throw new Exception($"Expecting a message with content but got null/empty");

            var msg = new AssistantChatMessage(text);
            _historic.Add(msg);
            NotifyMessage(msg);
        }

        private async Task<ChatCompletionOptions> GetOptions()
        {
            var options = new ChatCompletionOptions()
            {
                Temperature = 0.7f,
                MaxOutputTokenCount = 4096,
            };

            if(_mcpClient != null)
            {
                var tools = await _mcpClient.GetToolsForAzure();

                foreach (var tool in tools)
                    options.Tools.Add(tool);

                options.ToolChoice = ChatToolChoice.CreateAutoChoice();
                options.AllowParallelToolCalls = false;
            }

            return options;
        }

        private void NotifyMessage(ChatMessage message)
        {
            if(_callbackMsg != null)
                _callbackMsg(message);
        }

        public void RegisterMessageCallback(Action<ChatMessage> callback)
        {
            _callbackMsg = callback;
        }

        public void RegisterToolCallback(Func<string, string, bool> callback)
        {
            _callbackTool = callback;
        }
    }
}
