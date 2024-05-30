using DigiturnoAPI.Dtos.Request;
using DigiturnoAPI.Dtos.Response;
using DigiturnoAPI.Models;

namespace DigiturnoAPI.Interfaces
{
    public interface ITicketServices
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<IEnumerable<Ticket>> GetAllAvailableTicketsAsync();
        Task<IEnumerable<Ticket>> GetAllAssignTicketAsync();
        Task<IEnumerable<TicketTv>> GetTicketsTvAsync();
        Task<IEnumerable<Ticket>> GetAllCloseTicketAsync();
        Task<string> CreateTicketAsync(TicketRequestDto ticketRequestDto);
        Task<Ticket> UpdateTicketAsync(TicketModuleRequestDto ticketModuleRequestDto);
        Task<Ticket> GetAssignTicketAsync(string moduleId);
    }
}
