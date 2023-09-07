using FilmFusion.Application.Dtos.Request;
using FilmFusion.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmFusion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        private readonly ILogger<SyncController> _logger;
        private readonly IDatabaseService _databaseService;

        public SyncController(ILogger<SyncController> logger, 
            IDatabaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }

        [HttpPost("sql-server")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> Sync([FromBody] MoviePathRequest moviePathRequest)
        {
            _logger.LogInformation($"{HttpContext.TraceIdentifier} | {DateTime.Now} | Post Sync Sql-Server Movie Database: BEGIN");

            var result = await _databaseService.LoadMoviesSqlServer(moviePathRequest);

            _logger.LogInformation($"{HttpContext.TraceIdentifier} | {DateTime.Now} | Post Sync Sql-Server Movie Database: END");

            return Created("Loaded", result);
        }
    }
}
