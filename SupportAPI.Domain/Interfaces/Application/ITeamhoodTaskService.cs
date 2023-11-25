using SupportAPI.Domain.Contracts;
using SupportAPI.Domain.Contracts.Common;

namespace SupportAPI.Domain.Interfaces.Application
{
    public interface ITeamhoodTaskService
    {
        Task GetCustomFieldsAsync();
        Task<TeamhoodTask> CreateTeamhoodTaskAsync(TeamworkTicket teamworkTicket);
    }
}
