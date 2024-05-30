using DigiturnoAPI.Models;

namespace DigiturnoAPI.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<IEnumerable<Ticket>> GetAllAssignTicketsAsync();
        Task<IEnumerable<Ticket>> GetAllAvailableTicketsAsync();
        Task<IEnumerable<Ticket>> GetAllCloseTicketsAsycn();
        Task<Ticket> GetTicketByIdAsync(string id);
        Task<Ticket> GetTicketAvailableByModuleIdAsync(string id);
        Task<Ticket> CreateTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(string id, Ticket ticketIn);
        Task RemoveTicketAsync(Ticket ticketIn);
        Task RemoveTicketByIdAsync(string moduleId);
    }
}
