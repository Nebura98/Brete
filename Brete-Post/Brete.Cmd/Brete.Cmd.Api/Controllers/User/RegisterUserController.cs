using Brete.Cmd.Api.Commands.Skill;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class RegisterUserController : ControllerBase
{
    private readonly ILogger<RegisterUserController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public RegisterUserController(ICommandDispatcher commandDispatcher, ILogger<RegisterUserController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUserAsync(CreateSkillCommand command)
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
