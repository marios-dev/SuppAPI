using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SupportAPI.Domain.Contracts
{
    public class Included
    {
        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }
    }
}
