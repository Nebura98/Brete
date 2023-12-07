using Brete.Cmd.Api.Commands.Skill;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UpdateUserController : ControllerBase
{
    private readonly ILogger<UpdateUserController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public UpdateUserController(ICommandDispatcher commandDispatcher, ILogger<UpdateUserController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateUserAsync(Guid SkillId, UpdateSkillCommand command)
    {
        try
        {
            command.Id = SkillId;

            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Update User request completed successfully!"
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
