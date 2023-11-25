using System.Text.Json.Serialization;

namespace SupportAPI.Domain.Contracts.Common
{
    public class CustomField
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
