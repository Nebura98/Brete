using Brete.Cmd.Api.Commands.Job;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Job;

[Route("api/[controller]")]
[ApiController]
public class UpdateJobController : ControllerBase
{
    private readonly ILogger<UpdateJobController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public UpdateJobController(ILogger<UpdateJobController> logger, ICommandDispatcher commandDispatcher)
    {
        _logger = logger;
        _commandDispatcher = commandDispatcher;
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateJobAsync(Guid id, UpdateJobCommand command)
    {
        try
        {
            command.Id = id;

            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Update Job request completed successfully!"
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
