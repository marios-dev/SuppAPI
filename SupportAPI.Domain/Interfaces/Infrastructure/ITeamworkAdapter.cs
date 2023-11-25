using SupportAPI.Domain.BusinessModels;
using SupportAPI.Domain.Contracts;

namespace SupportAPI.Domain.Interfaces.Infrastructure
{
    public interface ITeamworkAdapter
    {
        Task<TeamworkTicket?> ChangeTeamworkTicketStatusAsync(Stream stream, int statusId);
        Task<TeamworkTicket?> ChangeTeamworkTicketStatusAsync(long id, int statusId);
        Task<TeamhoodBoardStatus> GetTeamhoodBoardStatusesAsync(string boardId);
        Task<TeamworkTicket?> GetFullTicketAsync(long id);
    }
}
