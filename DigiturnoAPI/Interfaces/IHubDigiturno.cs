using DigiturnoAPI.Models;

namespace DigiturnoAPI.Interfaces
{
    public interface IHubDigiturno
    {
        Task OnReceiveTicket(TicketRequestDto ticketRequestDto);
    }
}
