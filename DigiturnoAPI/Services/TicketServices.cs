using DigiturnoAPI.Constanst;
using DigiturnoAPI.Dtos.Request;
using DigiturnoAPI.Dtos.Response;
using DigiturnoAPI.Interfaces;
using DigiturnoAPI.Mappers;
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
        private readonly TicketMaps _ticketMaps;

        public TicketServices(ILogger<TicketServices> logger, IParamRepository paramRepository, ITicketRepository ticketRepository, TicketMaps ticketMaps)
        {
            _logger = logger;
            _paramRepository = paramRepository;
            _ticketRepository = ticketRepository;
            _ticketMaps = ticketMaps;
        }

        public async Task<IEnumerable<Ticket>> GetAllAssignTicketAsync()
        {
            return await _ticketRepository.GetAllAssignTicketsAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAllAvailableTicketsAsync()
        {
            return await _ticketRepository.GetAllAvailableTicketsAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAllCloseTicketAsync()
        {
            return await _ticketRepository.GetAllCloseTicketsAsycn();
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync() =>
            await _ticketRepository.GetAllTicketsAsync();

        public async Task<IEnumerable<TicketTv>> GetTicketsTvAsync()
        {
            List<Ticket> assignTicket = (await GetAllAssignTicketAsync()).ToList();
            return _ticketMaps.MapsToTicketsTv(assignTicket);
        }

        public async Task<Ticket> GetAssignTicketAsync(string moduleId)
        {
            return await _ticketRepository.GetTicketAvailableByModuleIdAsync(moduleId);
        }

        public async Task<string> CreateTicketAsync(TicketRequestDto ticketRequestDto)
        {
            Param param = await _paramRepository.GetConsecutiveAsync(ticketRequestDto.Handicapped);
            string firstletter = ticketRequestDto.Handicapped ? "D" : "T";
            string consecutiveNumber = param.Value < 10 ? $"00{param.Value}" : $"0{param.Value}";
            Ticket ticketData = new Ticket()
            {
                Name = ticketRequestDto.Name,
                Document = ticketRequestDto.Document,
                Handicapped = ticketRequestDto.Handicapped,
                TypeService = ticketRequestDto.TypeService,
                TicketNumber = $"{firstletter}{consecutiveNumber}",
                Status = StatusTicket.Available,
                ModuleId = "",
                CreatedAt = DateTime.Now,
                TicketId = ObjectId.GenerateNewId().ToString(),
            };

            await _ticketRepository.CreateTicketAsync(ticketData);
            _logger.LogInformation("Se ha creado el ticket");
            await _paramRepository.UpdateConsecutiveAsync(ticketRequestDto.Handicapped);
            return ticketData.TicketNumber;
        }
        public async Task<Ticket> UpdateTicketAsync(TicketModuleRequestDto ticketModuleRequestDto)
        {
            Ticket ticket = await _ticketRepository.GetTicketByIdAsync(ticketModuleRequestDto.Id);
            ticket.Status = ticketModuleRequestDto.Status;
            ticket.ModuleId = ticketModuleRequestDto.moduleId;
            await _ticketRepository.UpdateTicketAsync(ticketModuleRequestDto.Id, ticket);
            return ticket;
        }
    }
}
