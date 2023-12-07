using Brete.Cmd.Api.Commands.Job;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Job;

[Route("api/[controller]")]
[ApiController]
public class DeleteJobController : ControllerBase
{

    private readonly ILogger<DeleteJobController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public DeleteJobController(ICommandDispatcher commandDispatcher, ILogger<DeleteJobController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> DisableJobAsync(Guid id, DeleteJobCommand command)
    {
        try
        {
            command.Id = id;

            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Delete Job request completed successfully!"
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
