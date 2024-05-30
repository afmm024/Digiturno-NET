using DigiturnoAPI.Dtos.Response;
using DigiturnoAPI.Models;

namespace DigiturnoAPI.Mappers
{
    public class TicketMaps
    {
        public TicketTv MapToTicketTv(TicketTv ticket)
        {
            return new TicketTv { Id = ticket.Id, ModuleId = ticket.ModuleId, TicketNumber = ticket.TicketNumber };
        }

        public IEnumerable<TicketTv> MapsToTicketsTv(IEnumerable<Ticket> ticket) { 
            List<TicketTv> ticketTvs = new List<TicketTv>();

            foreach(Ticket t in ticket)
            {
                ticketTvs.Add(new TicketTv { Id = t.Id, ModuleId = t.ModuleId, TicketNumber = t.TicketNumber });
            }

            return ticketTvs;

        }
    }
}
