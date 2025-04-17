using System.Text.Json;

namespace Client.Utils
{
    public static class FormatJSON
    {
        public static string FromBinaryData(BinaryData data)
        {
            using JsonDocument doc = JsonDocument.Parse(data);

            return JsonSerializer.Serialize(doc.RootElement, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
