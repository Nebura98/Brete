using Brete.Cmd.Api.Commands.Skill;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Skill;

[Route("api/[controller]")]
[ApiController]
public class DisableSkillController : ControllerBase
{

    private readonly ILogger<DisableSkillController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public DisableSkillController(ICommandDispatcher commandDispatcher, ILogger<DisableSkillController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> DisableSkillAsync(Guid id, DisableSkillCommand command)
    {
        try
        {
            command.Id = id;

            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Disable Job request completed successfully!"
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
