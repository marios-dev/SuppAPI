using Microsoft.Extensions.Logging;
using SupportAPI.Domain;
using SupportAPI.Domain.BusinessModels;
using SupportAPI.Domain.Contracts;
using SupportAPI.Domain.Contracts.Common;
using SupportAPI.Domain.Interfaces.Infrastructure;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using static SupportAPI.Domain.Constants;

namespace SupportAPI.Infrastucture
{
    public class TeamhoodAdapter : ITeamhoodAdapter
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TeamhoodAdapter> _logger;

        public TeamhoodAdapter(IHttpClientFactory httpClientFactory, ILogger<TeamhoodAdapter> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<TeamhoodTask> CreateTaskAsync(TeamhoodTask teamhoodTask)
        {
            try
            {
                using (var teamhoodClient = _httpClientFactory.CreateClient(Constants.HttpClientTeamhood))
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, teamhoodClient.BaseAddress + "items");
                    var uri = new Uri(teamhoodClient.BaseAddress + "items");
                    var jsonContent = JsonSerializer.Serialize(teamhoodTask);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    using var response = await teamhoodClient.PostAsync(uri,content);
                    if (response.IsSuccessStatusCode)
                    {
                        using var jsonStream = await response.Content.ReadAsStreamAsync();
                        var deserializedTeamhoodTask = await JsonSerializer.DeserializeAsync<TeamhoodTask>(jsonStream);
                        if (deserializedTeamhoodTask is not null)
                        {
                            return deserializedTeamhoodTask;
                        }
                    }
                    return new TeamhoodTask();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TeamhoodTask> CreateTaskObject(TeamworkTicket teamworkTicket)
        {
            var task = new TeamhoodTask()
            {
                WorkspaceId = Constants.TeamhoodTaskInfo.WorkspaceID,
                BoardId = Constants.TeamhoodTaskInfo.BoardID,
                RowId = Constants.TeamhoodTaskInfo.RowID,
                StatusId = Constants.TeamhoodTaskInfo.ToDoStatusID,
                Title = teamworkTicket.Ticket.Subject,
                Description = teamworkTicket.Ticket.PreviewText,
                IsSuspended = false,
                Milestone = false,
                Completed = false,
                CustomFields = await GetCustomFields(teamworkTicket),
                Tags = new List<string>(),
                Progress = 0,
                Color = 1
            };
            return task;
        }

        public async Task<List<CustomField>> GetCustomFields(TeamworkTicket teamworkTicket)
        {
            if (teamworkTicket is null)
            {
                return new List<CustomField>();
            }
            var ticketURL = $"{Constants.TeamhoodTaskInfo.TeamworkCompanyEndpoint}/desk/tickets/{teamworkTicket.Ticket.Id}/messages";
            var customFieldList = new List<CustomField>()
            {
                new CustomField { Name = "Task Priority", Value = "P2" },
                new CustomField { Name = "Sub Status", Value = "To be planned" },
                new CustomField { Name = "Client", Value = teamworkTicket.Included.Tags?[0]?.Name },
                new CustomField { Name = "Ticket", Value = ticketURL },
                new CustomField { Name = "TicketID", Value = teamworkTicket.Ticket.Id.ToString() },
                new CustomField { Name = "Message Count", Value = teamworkTicket.Ticket.MessageCount.ToString() 
            }};
            return customFieldList;
        }
    }
}
