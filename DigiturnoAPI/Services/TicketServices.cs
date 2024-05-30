using DigiturnoAPI.Dtos.Request;
using DigiturnoAPI.Interfaces;
using DigiturnoAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DigiturnoAPI.Services
{
    public class TicketServices : ITicketServices
    {

        private readonly ILogger<TicketServices> _logger;
        private readonly IParamRepository _paramRepository;
        private readonly ITicketRepository _ticketRepository;

        public TicketServices(ILogger<TicketServices> logger, IParamRepository paramRepository, ITicketRepository ticketRepository)
        {
            _logger = logger;
            _paramRepository = paramRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<string> CreateTicketAsync(TicketRequestDto ticketRequestDto)
        {
            Param param = await _paramRepository.GetConsecutiveAsync(ticketRequestDto.Handicapped);
            string firstletter = ticketRequestDto.Handicapped ? "D" : "T";
            string consecutiveNumber = param.Value < 10 ? $"00{param.Value}" : $"0{param.Value}";
            Ticket ticketData = new Ticket() {
                Name = ticketRequestDto.Name,
                Document = ticketRequestDto.Document,
                Handicapped = ticketRequestDto.Handicapped,
                TypeService = ticketRequestDto.TypeService,
                TicketNumber = $"{firstletter}+ñ{consecutiveNumber}",
                Status = StatusTicketEnum.Available,
                ModuleId = "",
                CreatedAt = DateTime.Now,
                TicketId = ObjectId.GenerateNewId().ToString(),
            };

            await _ticketRepository.CreateTicketAsync(ticketData);
            _logger.LogInformation("Se ha creado el ticket");
            await _paramRepository.UpdateConsecutiveAsync(ticketRequestDto.Handicapped);
            return ticketData.TicketNumber;
        }

        public async Task<IEnumerable<Ticket>> GetAllAssignTicketAsync()
        {
            return await _ticketRepository.GetAllAssingTicketsAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAllAvailableTicketsAsync()
        {
            List<Ticket> tickets = (await _ticketRepository.GetAllTicketsAsync()).ToList();
            return tickets.Where(t => t.Status.Equals(StatusTicketEnum.Available));
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketAssignAsync()
        {
            List<Ticket> tickets = (await _ticketRepository.GetAllTicketsAsync()).ToList();
            return tickets.Where(t => t.Status.Equals(StatusTicketEnum.Assign));
        }

        public async Task<Ticket> GetAssignTicketAsync(string moduleId)
        {
            return await _ticketRepository.GetTicketAvailableByModuleIdAsync(moduleId);
        }

        public async Task<Ticket> UpdateTicketAsync(string moduleId, string ticketId, StatusTicketEnum status)
        {
            Ticket ticket = await _ticketRepository.GetTicketByIdAsync(ticketId);
            ticket.Status = status;
            ticket.ModuleId = moduleId;
            await _ticketRepository.UpdateTicketAsync(ticketId, ticket);
            return ticket;
        }
    }
}
