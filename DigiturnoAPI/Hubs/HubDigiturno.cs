using Microsoft.AspNetCore.SignalR;
using DigiturnoAPI.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using DigiturnoAPI.Models;

namespace DigiturnoAPI.Hubs
{
    public sealed class HubDigiturno : Hub
    {
         private readonly IMemoryCache _memoryCache;

         public HubDigiturno(IMemoryCache memoryCache)
         {
             _memoryCache = memoryCache;
         }

         public async Task OnReceiveTicket(TicketRequestDto ticketRequestDto)
         {
             await Clients.All.SendAsync("ReceiveTicket", ticketRequestDto);
         }

         public override async Task OnConnectedAsync()
        {
            
            await base.OnConnectedAsync();
        }     

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}