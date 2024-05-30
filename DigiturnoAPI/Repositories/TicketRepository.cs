using DigiturnoAPI.Interfaces;
using DigiturnoAPI.Models;
using MongoDB.Driver;

namespace DigiturnoAPI.Services;

public class TicketRepository : ITicketRepository
{
    private readonly IMongoCollection<Ticket> _tickets;
    public TicketRepository(DatabaseProvider databaseProvider)
    {
        _tickets = databaseProvider.GetAccess().GetCollection<Ticket>("tickets");
    }

    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync() =>
        await _tickets.Find(ticket => true).ToListAsync();

    public async Task<Ticket> GetTicketByIdAsync(string id) =>
        await _tickets.Find<Ticket>(ticket => ticket.Id.Equals(id)).FirstOrDefaultAsync();

    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
        await _tickets.InsertOneAsync(ticket);
        return ticket;
    }

    public async Task UpdateTicketAsync(string id, Ticket ticketIn) =>
        await _tickets.ReplaceOneAsync(ticket => ticket.Id.Equals(id), ticketIn);

    public async Task RemoveTicketAsync(Ticket ticketIn) =>
        await _tickets.DeleteOneAsync(ticket => ticket.Id.Equals(ticketIn.Id));

    public async Task RemoveTicketByIdAsync(string id) =>
        await _tickets.DeleteOneAsync(ticket => ticket.Id.Equals(id));

    public async Task<Ticket> GetTicketAvailableByModuleIdAsync(string moduleId)
    {
       return await _tickets.Find<Ticket>(ticket => ticket.ModuleId.Equals(moduleId) && ticket.Status.Equals(StatusTicketEnum.Available)).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Ticket>> GetAllAssingTicketsAsync()
    {
        return await _tickets.Find<Ticket>(ticket => ticket.Status.Equals(StatusTicketEnum.Assign)).ToListAsync();
    }
}