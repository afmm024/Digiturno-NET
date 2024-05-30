using DigiturnoAPI.Dtos.Request;
using DigiturnoAPI.Models;

namespace DigiturnoAPI.Interfaces
{
    public interface ITicketServices
    {
        Task<string> CreateTicketAsync(TicketRequestDto ticketRequestDto);
        Task<Ticket> UpdateTicketAsync(string moduleId, string ticketId, StatusTicketEnum status);
        Task<IEnumerable<Ticket>> GetAllAvailableTicketsAsync();
        Task<IEnumerable<Ticket>> GetAllAssignTicketAsync();
        Task<Ticket> GetAssignTicketAsync(string moduleId);
    }
}
