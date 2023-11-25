using System.Text.Json.Serialization;

namespace SupportAPI.Domain.BusinessModels
{
    public class TaskStatus
    {
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
