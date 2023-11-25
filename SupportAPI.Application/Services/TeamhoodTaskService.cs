using SupportAPI.Domain.Contracts;
using SupportAPI.Domain.Contracts.Common;
using SupportAPI.Domain.Interfaces.Application;
using SupportAPI.Domain.Interfaces.Infrastructure;

namespace SupportAPI.Application.Services
{
    public class TeamhoodTaskService : ITeamhoodTaskService
    {
        private readonly ITeamhoodAdapter _teamhoodAdapter;

        public TeamhoodTaskService(ITeamhoodAdapter teamhoodAdapter)
        {
            _teamhoodAdapter = teamhoodAdapter;
        }
        public async Task<TeamhoodTask> CreateTeamhoodTaskAsync(TeamworkTicket teamworkTicket)
        {
            var task = await _teamhoodAdapter.CreateTaskObject(teamworkTicket);
            var createdTask = await _teamhoodAdapter.CreateTaskAsync(task);
            if (createdTask is null)
            {
                return createdTask;
            }
            return new TeamhoodTask();
        }

        public Task GetCustomFieldsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
