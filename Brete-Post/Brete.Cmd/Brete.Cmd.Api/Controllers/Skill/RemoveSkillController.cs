using Brete.Cmd.Api.Commands.Skill;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Skill;

[Route("api/[controller]")]
[ApiController]
public class RemoveSkillController : ControllerBase
{
    private readonly ILogger<RemoveSkillController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public RemoveSkillController(ICommandDispatcher commandDispatcher, ILogger<RemoveSkillController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveSkillAsync(Guid SkillId, RemoveSkillCommand command)
    {
        try
        {
            command.Id = SkillId;

            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Remove Skill request completed successfully!"
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
