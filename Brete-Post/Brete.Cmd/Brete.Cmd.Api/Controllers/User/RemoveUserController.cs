using Brete.Cmd.Api.Commands.Skill;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class RemoveUserController : ControllerBase
{
    private readonly ILogger<RemoveUserController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public RemoveUserController(ICommandDispatcher commandDispatcher, ILogger<RemoveUserController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveUserAsync(Guid SkillId, DeleteSkillCommand command)
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
