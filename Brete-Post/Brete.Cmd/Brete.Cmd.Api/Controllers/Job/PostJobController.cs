using Brete.Cmd.Api.Commands.Job;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Job;

[Route("api/[controller]")]
[ApiController]
public class PostJobController : ControllerBase
{
    private readonly ILogger<PostJobController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public PostJobController(ICommandDispatcher commandDispatcher, ILogger<PostJobController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> PostJobAsync(CreateJobCommand command)
    {
        try
        {
            command.Id = Guid.NewGuid();
            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Add Job request completed successfully!"
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
