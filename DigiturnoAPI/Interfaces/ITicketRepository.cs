using DigiturnoAPI.Models;

namespace DigiturnoAPI.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<IEnumerable<Ticket>> GetAllAssingTicketsAsync();

        Task<Ticket> GetTicketByIdAsync(string id);
        Task<Ticket> GetTicketAvailableByModuleIdAsync(string id);
        Task<Ticket> CreateTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(string id, Ticket ticketIn);
        Task RemoveTicketAsync(Ticket ticketIn);
        Task RemoveTicketByIdAsync(string moduleId);
    }
}
