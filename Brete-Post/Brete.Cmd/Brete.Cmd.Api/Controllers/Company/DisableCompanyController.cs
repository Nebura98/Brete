using Brete.Cmd.Api.Commands.Company;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Company;

[Route("api/[controller]")]
[ApiController]
public class DisableCompanyController : ControllerBase
{

    private readonly ILogger<DisableCompanyController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public DisableCompanyController(ICommandDispatcher commandDispatcher, ILogger<DisableCompanyController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> DisableCompanyAsync(Guid id, DisableCompanyCommand command)
    {
        try
        {
            command.Id = id;

            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Disable Company request completed successfully!"
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
