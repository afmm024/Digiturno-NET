

using DigiturnoAPI.Hubs;
using DigiturnoAPI.Interfaces;
using DigiturnoAPI.Models;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;

namespace DigiturnoAPI.Services;

public class TicketsService : ITicketServices {
    private readonly IMongoCollection<Ticket> _tickets;
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IHubContext<HubDigiturno> _hubContext;

    public TicketsService(DatabaseProvider databaseProvider, IHubContext<HubDigiturno> hubContext)
    {
        _mongoDatabase = databaseProvider.GetAccess();
        _hubContext = hubContext;
        _tickets = _mongoDatabase.GetCollection<Ticket>("tickets");
    }

    public async Task<List<Ticket>> Get() =>
        await _tickets.Find(ticket => true).ToListAsync();

    public async Task<Ticket> Get(string id) =>
        await _tickets.Find<Ticket>(ticket => ticket.Id == id).FirstOrDefaultAsync();

    public async Task<Ticket> Create(Ticket ticket)
    {
        await _tickets.InsertOneAsync(ticket);
        return ticket;
    }

    public async Task Update(string id, Ticket ticketIn) =>
        await _tickets.ReplaceOneAsync(ticket => ticket.Id == id, ticketIn);

    public async Task Remove(Ticket ticketIn) =>
        await _tickets.DeleteOneAsync(ticket => ticket.Id == ticketIn.Id);

    public async Task Remove(string id) =>
        await _tickets.DeleteOneAsync(ticket => ticket.Id == id);

}