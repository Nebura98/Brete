using Brete.Cmd.Api.Commands.Skill;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Skill;

[Route("api/[controller]")]
[ApiController]
public class UpdateSkillController : ControllerBase
{
    private readonly ILogger<UpdateSkillController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public UpdateSkillController(ICommandDispatcher commandDispatcher, ILogger<UpdateSkillController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateSkillAsync(Guid id, UpdateSkillCommand command)
    {
        try
        {
            command.Id = id;

            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Update Skill request completed successfully!"
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
