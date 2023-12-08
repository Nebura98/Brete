using Brete.Cmd.Api.Commands.Skill;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Skill;

[Route("api/[controller]")]
[ApiController]
public class DeleteSkillController : ControllerBase
{
    private readonly ILogger<DeleteSkillController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public DeleteSkillController(ICommandDispatcher commandDispatcher, ILogger<DeleteSkillController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveSkillAsync(Guid id, DeleteSkillCommand command)
    {
        try
        {
            command.Id = id;

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
