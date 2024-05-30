using DigiturnoAPI.Dtos.Request;

namespace DigiturnoAPI.Interfaces
{
    public interface IHubDigiturno
    {
        Task OnReceiveTicket(TicketRequestDto ticketRequestDto);
    }
}
