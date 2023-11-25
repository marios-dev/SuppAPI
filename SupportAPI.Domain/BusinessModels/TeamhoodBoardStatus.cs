using System.Text.Json.Serialization;


namespace SupportAPI.Domain.BusinessModels
{
    public partial class TeamhoodBoardStatus
    {
        public List<Status> Statuses { get; set; }
        
    }
    public partial class Status
    {
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
