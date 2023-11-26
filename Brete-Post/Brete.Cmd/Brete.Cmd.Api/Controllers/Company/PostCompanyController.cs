using Brete.Cmd.Api.Commands.Skill;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Company;

[Route("api/[controller]")]
[ApiController]
public class PostCompanyController : ControllerBase
{
    private readonly ILogger<PostCompanyController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public PostCompanyController(ICommandDispatcher commandDispatcher, ILogger<PostCompanyController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> PostCompanyAsync(CreateCompanyCommand command)
    {
        try
        {
            command.Id = Guid.NewGuid();
            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Add Company request completed successfully!"
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
