using SupportAPI.Domain;
using SupportAPI.Domain.Contracts;
using SupportAPI.Domain.Interfaces.Application;
using SupportAPI.Domain.Interfaces.Infrastructure;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace SupportAPI.Application.Services
{
    public class TeamworkTicketService : ITeamworkTicketService
    {
        private readonly ITeamworkAdapter _teamworkAdapter;
        private readonly ITeamhoodTaskService _teamhoodTaskService;

        public TeamworkTicketService(ITeamworkAdapter teamworkAdapter, ITeamhoodTaskService teamhoodTaskService)
        {
            _teamworkAdapter = teamworkAdapter;
            _teamhoodTaskService = teamhoodTaskService;
        }

        public async Task<long> UpdateTicketStatusAsync(Stream stream, int ticketStatusID)
        {
            var updatedTicket = await _teamworkAdapter.ChangeTeamworkTicketStatusAsync(stream, ticketStatusID);

            if (updatedTicket is not null)
            {
                return 200;
            }
            else
            {
                return 0;
            }
        }

        public async Task<long> CreateTicketAtTeamhoodAsync(Stream stream)
        {
            var deserializedTicket = await JsonSerializer.DeserializeAsync<TicketStatusChangedObject>(stream);
            if (deserializedTicket == null)
            {
                return 0;
            }
            if (deserializedTicket is not null)
            {
                var fullTeamworkTicket = await _teamworkAdapter.GetFullTicketAsync(deserializedTicket.Id);
                if (fullTeamworkTicket is null)
                {
                    return 0;
                }

                var teamhoodTask = await _teamhoodTaskService.CreateTeamhoodTaskAsync(fullTeamworkTicket);
                if (teamhoodTask is null)
                {
                    return 0;
                }

                var updatedTicket = await _teamworkAdapter.ChangeTeamworkTicketStatusAsync(fullTeamworkTicket.Ticket.Id,Constants.TeamWorkStatusIdFor.CreatedInTeamhood);
                if (teamhoodTask is null)
                {
                    return 0;
                }
            }
            return 200;

        }

    }
}
