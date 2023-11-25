using System.Text.Json.Serialization;

namespace SupportAPI.Domain.Contracts.Common
{
    public class TeamhoodTask
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("boardid")]
        public Guid BoardId { get; set; }

        [JsonPropertyName("assigneduserid")]
        public Guid? AssignedUserId { get; set; }

        [JsonPropertyName("ownerid")]
        public Guid? OwnerId { get; set; }
        [JsonPropertyName("rowid")]
        public Guid RowId { get; set; }
        [JsonPropertyName("statusid")]
        public Guid StatusId { get; set; }
        [JsonPropertyName("startdate")]
        public DateTimeOffset? StartDate { get; set; }
        [JsonPropertyName("duedate")]
        public DateTimeOffset? DueDate { get; set; }
        [JsonPropertyName("color")]
        public long? Color { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
        [JsonPropertyName("workspaceid")]
        public Guid WorkspaceId { get; set; }
        [JsonPropertyName("milestone")]
        public bool Milestone { get; set; }
        [JsonPropertyName("progress")]
        public long? Progress { get; set; }
        [JsonPropertyName("issuspended")]
        public bool IsSuspended { get; set; }
        [JsonPropertyName("customfields")]
        public List<CustomField> CustomFields { get; set; }
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
