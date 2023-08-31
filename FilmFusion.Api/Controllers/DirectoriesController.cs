using FilmFusion.Application.Dtos.Request;
using FilmFusion.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmFusion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoriesController : ControllerBase
    {
        private readonly ILogger<DirectoriesController> _logger;
        private readonly IDirectoryService _directoryService;

        public DirectoriesController(ILogger<DirectoriesController> logger,
            IDirectoryService directoryService)
        {
            _logger = logger;
            _directoryService = directoryService;
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> Update([FromBody] MoviePathRequest moviePathRequest)
        {
            _logger.LogInformation($"{HttpContext.TraceIdentifier} | {DateTime.Now} | Put Update Directories: BEGIN");

            var result = await _directoryService.UpdatePath(moviePathRequest);

            _logger.LogInformation($"{HttpContext.TraceIdentifier} | {DateTime.Now} | Put Update Directories: END");

            return Ok(result);
        }
    }
}
