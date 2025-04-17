using Client.Clients;
using Client.Utils;

namespace Client
{
    class Program
    {
        private static readonly string AzureOpenAIEndpoint = "YOUR_ENDPOINT";
        private static readonly string AzureOpenAIApiKey = "YOUR_KEY";
        private static readonly string AzureDeploymentName = "YOUR_DEPLOYMENT_NAME";

        static async Task Main()
        {
            McpClient client = new McpClient(
                name: "SQL-SERVER_MCP",
                command: "dotnet",
                arguments: ["run", "--project", "C:\\Users\\RodrigoDev\\Desktop\\Projects\\MCP-SqlServer", "--no-build"]
            );

            await client.Connect();

            var chat = new LLMClient(
                AzureOpenAIEndpoint, 
                AzureOpenAIApiKey, 
                AzureDeploymentName
            );

            chat.SetMcpClient(client);

            bool continueChat = true;

            chat.RegisterMessageCallback(message =>
            {
                PrintChat.Print(chat.GetHistoric());
            });

            chat.RegisterToolCallback((name, data) =>
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Authorize tool {name} with args {data}? Y/N");
                Console.ForegroundColor = ConsoleColor.White;

                string userInput = Console.ReadLine() ?? string.Empty;

                return userInput == "Y" || userInput == "y";
            });

            while (continueChat)
            {
                string userInput = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrEmpty(userInput) || userInput.ToLower() == "exit")
                {
                    continueChat = false;
                    continue;
                }

                await chat.SendMessage(userInput);
            }
        }
    }
}