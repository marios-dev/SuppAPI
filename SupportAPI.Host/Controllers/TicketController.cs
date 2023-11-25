using Microsoft.AspNetCore.Mvc;
using SupportAPI.Domain;
using SupportAPI.Domain.Interfaces.Application;

namespace SupportAPI.Host.Controllers
{
    //[Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITeamworkTicketService _teamworkTicketService;
        private readonly ILogger<TicketController> _logger;

        public TicketController(ILogger<TicketController> logger, ITeamworkTicketService teamworkTicketService)
        {
            _logger = logger;
            _teamworkTicketService = teamworkTicketService;
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> GetTicketAsync()
        {
            long result = 0;
            if (HttpContext.Request.Headers.TryGetValue("x-desk-event", out var value))
            {
                switch (value)
                {
                    case Constants.TicketCreated:
                        //
                        result = await _teamworkTicketService.UpdateTicketStatusAsync(HttpContext.Request.Body, Constants.TeamWorkStatusIdFor.ToTeamhood);
                        if (result is 0)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, result);
                        }
                        break;
                    case Constants.TicketStatus:
                        result = await _teamworkTicketService.CreateTicketAtTeamhoodAsync(HttpContext.Request.Body);
                        if (result is 0)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, result);
                        }
                        break;
                    default:
                        return StatusCode(StatusCodes.Status404NotFound, result);
                }
            }
            return Ok(result);
        }
    }
}
