using DigiturnoAPI.Models;

namespace DigiturnoAPI.Interfaces
{
    public interface ITicketServices
    {
        Task<List<Ticket>> Get();
        Task<Ticket> Get(string id);
        Task<Ticket> Create(Ticket ticket);
        Task Update(string id, Ticket ticketIn);
        Task Remove(Ticket ticketIn);
        Task Remove(string id);
    }
}
