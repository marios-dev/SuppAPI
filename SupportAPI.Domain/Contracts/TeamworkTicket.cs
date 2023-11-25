using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace SupportAPI.Domain.Contracts
{
    public partial class TeamworkTicket
    {
        [JsonPropertyName("ticket")]
        public Ticket Ticket { get; set; }
        [JsonPropertyName("included")]
        public Included? Included { get; set; }

        public void ChangeTicketStatusTo(int statusID)
        {
            this.Ticket.Status.Id = statusID;
        }
    }
}