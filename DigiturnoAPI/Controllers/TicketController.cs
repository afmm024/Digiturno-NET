using Microsoft.AspNetCore.Mvc;
using DigiturnoAPI.Interfaces;
using DigiturnoAPI.Models;

namespace DigiturnoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {

        private readonly ITicketServices _ticketServices;
        // private readonly ILogger<WeatherForecastController> _logger;
        
        public TicketController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }   
        
        [HttpPost("ticket")]
        public async Task<IActionResult> CreateTicket(TicketRequestDto ticketDto)
        {
            //await _ticketServices.CreateTicket(ticketDto);

            return Ok(ticketDto);
        }

        [HttpGet("ticket")]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _ticketServices.Get();

            return Ok(tickets);
        }
    }
}
