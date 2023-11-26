using Brete.Cmd.Api.Commands.Job;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Job;

[Route("api/[controller]")]
[ApiController]
public class DisableCompanyController : ControllerBase
{

    private readonly ILogger<DisableCompanyController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public DisableCompanyController(ICommandDispatcher commandDispatcher, ILogger<DisableCompanyController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpPut]
    public async Task<IActionResult> DisableJobAsync(Guid JobId, DisableJobCommand command)
    {
        try
        {
            command.Id = JobId;

            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Disable Job request completed successfully!"
            });
        }
        catch (InvalidOperationException ex)
        {
            _logger.Log(LogLevel.Warning, ex, "Client made a bad request!");
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        }
    }
}
