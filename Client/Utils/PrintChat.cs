using OpenAI.Chat;

namespace Client.Utils
{
    public static class PrintChat
    {
        public static void Print(List<ChatMessage> messages)
        {
            Console.Clear();
            foreach(var message in messages)
            {
                if (message is UserChatMessage)
                    PrintUserMessage(message as UserChatMessage);

                if(message is AssistantChatMessage)
                    PrintAssistantMessage(message as AssistantChatMessage);

                if (message is ToolChatMessage)
                    PrintToolMessage(message as ToolChatMessage);
            }
        }

        private static void PrintUserMessage(UserChatMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[User]: " + GetTextFromCollection(message.Content));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintAssistantMessage(AssistantChatMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[Assistant]: " + GetTextFromCollection(message.Content));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintToolMessage(ToolChatMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Tool]: " + message.ToolCallId + " " + GetTextFromCollection(message.Content));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static string GetTextFromCollection(ChatMessageContent content)
        {
            var result = string.Empty;

            foreach(var part in content)
            {
                result+= part.Text; 
            }

            return result;
        }
    }
}
