namespace SupportAPI.Domain.Interfaces.Application
{
    public interface ITeamworkTicketService
    {
        Task<long> UpdateTicketStatusAsync(Stream stream, int ticketStatusID);
        Task<long> CreateTicketAtTeamhoodAsync(Stream stream);
    }
}
