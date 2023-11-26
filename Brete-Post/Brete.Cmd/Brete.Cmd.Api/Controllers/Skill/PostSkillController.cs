using Brete.Cmd.Api.Commands.Skill;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Skill;

[Route("api/[controller]")]
[ApiController]
public class PostSkillController : ControllerBase
{
    private readonly ILogger<PostSkillController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public PostSkillController(ICommandDispatcher commandDispatcher, ILogger<PostSkillController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> PostSkillAsync(CreateSkillCommand command)
    {
        try
        {
            command.Id = Guid.NewGuid();
            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Add Skill request completed successfully!"
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
