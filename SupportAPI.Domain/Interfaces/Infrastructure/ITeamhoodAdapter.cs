using SupportAPI.Domain.Contracts;
using SupportAPI.Domain.Contracts.Common;

namespace SupportAPI.Domain.Interfaces.Infrastructure
{
    public interface ITeamhoodAdapter
    {
        Task<TeamhoodTask> CreateTaskObject(TeamworkTicket teamworkTicket);
        Task<TeamhoodTask> CreateTaskAsync(TeamhoodTask teamhoodTask);
    }
}
