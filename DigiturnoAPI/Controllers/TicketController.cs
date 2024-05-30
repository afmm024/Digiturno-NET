using Microsoft.AspNetCore.Mvc;
using DigiturnoAPI.Interfaces;
using DigiturnoAPI.Dtos.Request;
using Microsoft.AspNetCore.SignalR;
using DigiturnoAPI.Hubs;
using DigiturnoAPI.Constanst;

namespace DigiturnoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {

        private readonly ITicketServices _ticketServices;
        private readonly IHubContext<HubDigiturno> _hubContext;

        public TicketController(ITicketServices ticketServices, IHubContext<HubDigiturno> hubContext)
        {
            _ticketServices = ticketServices;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketRequestDto ticketDto)
        {
            var ticketNumber = await _ticketServices.CreateTicketAsync(ticketDto);
            await _hubContext.Clients.All.SendAsync(TicketsEventsHub.GetAvailableTickets,
                await _ticketServices.GetAllAvailableTicketsAsync());
            return StatusCode(201, ticketNumber);
        }

        [HttpGet("assign")]
        public async Task<IActionResult> GetASsignTickets()
        {
            return Ok(await _ticketServices.GetAllAssignTicketAsync());
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableTickets()
        {
            return Ok(await _ticketServices.GetAllAvailableTicketsAsync());
        }

        [HttpGet("close")]
        public async Task<IActionResult> GetCloseTickets()
        {
            return Ok(await _ticketServices.GetAllCloseTicketAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ticketServices.GetAllTicketsAsync());
        }
    }
}
