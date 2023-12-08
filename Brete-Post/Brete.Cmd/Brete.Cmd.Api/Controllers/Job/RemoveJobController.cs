using Brete.Cmd.Api.Commands.Job;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Job;

[Route("api/[controller]")]
[ApiController]
public class RemoveJobController : ControllerBase
{
    private readonly ILogger<RemoveJobController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public RemoveJobController(ICommandDispatcher commandDispatcher, ILogger<RemoveJobController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveJobAsync(Guid id, RemoveJobCommand command)
    {
        try
        {
            command.Id = id;

            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Remove Job request completed successfully!"
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
