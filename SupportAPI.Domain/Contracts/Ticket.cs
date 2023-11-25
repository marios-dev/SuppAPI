using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SupportAPI.Domain.Contracts
{
    public class Ticket
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("readonly")]
        public bool? Readonly { get; set; }

        [JsonPropertyName("messageCount")]
        public long? MessageCount { get; set; }

        [JsonPropertyName("previewText")]
        public string PreviewText { get; set; }

        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }
        [JsonPropertyName("status")]
        public Status Status { get; set; }
    }
}
