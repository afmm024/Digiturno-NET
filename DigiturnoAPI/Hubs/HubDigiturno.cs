using Microsoft.AspNetCore.SignalR;
using DigiturnoAPI.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using DigiturnoAPI.Dtos.Request;
using DigiturnoAPI.Constanst;
using DigiturnoAPI.Dtos.Response;

namespace DigiturnoAPI.Hubs
{
    public sealed class HubDigiturno : Hub
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ITicketServices _ticketServices;
        private readonly ILogger<HubDigiturno> _logger;

        public HubDigiturno(IMemoryCache memoryCache, ITicketServices ticketServices, ILogger<HubDigiturno> logger)
        {
            _memoryCache = memoryCache;
            _ticketServices = ticketServices;
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            await Clients.Client(Context.ConnectionId).SendAsync(
                $"Welcome to === DIGITURNO WS ====");

        }

        public async Task GetAvailableTickets ()
        {
            await Clients.All.SendAsync(TicketsEventsHub.GetAvailableTickets, await _ticketServices.GetAllAvailableTicketsAsync());
        }

        public async Task GetAssignTicket (string moduleId)
        {
            await Clients.All.SendAsync(TicketsEventsHub.GetAssignTicket, await _ticketServices.GetAssignTicketAsync(moduleId));
        }


        public async Task UpdateStatusTicket(TicketModuleRequestDto ticketInModule)
        {
            await _ticketServices.UpdateTicketAsync(ticketInModule);
            await GetAvailableTickets();
            await GetAssignTicket(ticketInModule.Id);
        }

        public async Task GetTicketsForTv()
        {
            await Clients.All.SendAsync(TicketsEventsHub.TvTickets, await _ticketServices.GetTicketsTvAsync());
        }

        public async Task CallTickets(TicketTv ticketTv)
        {
            await Clients.All.SendAsync(TicketsEventsHub.CallTickets, ticketTv);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnConnectedAsync();
            await Clients.All.SendAsync("ReceiveMessage", "System", "A new user has connected.");
        }
    }
}