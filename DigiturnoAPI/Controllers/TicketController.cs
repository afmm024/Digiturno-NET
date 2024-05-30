using Microsoft.AspNetCore.Mvc;
using DigiturnoAPI.Interfaces;
using DigiturnoAPI.Dtos.Request;

namespace DigiturnoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {

        private readonly ITicketServices _ticketServices;
        
        public TicketController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }   
        
        [HttpPost("ticket")]
        public async Task<IActionResult> CreateTicket(TicketRequestDto ticketDto)
        {
            return Ok(await _ticketServices.CreateTicketAsync(ticketDto));
        }

        [HttpGet("ticket/active")]
        public async Task<IActionResult> GetTickets()
        {
            return Ok(await _ticketServices.GetAllAvailableTicketsAsync());
        }
    }
}
