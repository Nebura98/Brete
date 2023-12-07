using Brete.Cmd.Api.Commands.Company;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Company;

[Route("api/[controller]")]
[ApiController]
public class RemoveCompanyController : ControllerBase
{
    private readonly ILogger<RemoveCompanyController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public RemoveCompanyController(ICommandDispatcher commandDispatcher, ILogger<RemoveCompanyController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCompanyAsync(Guid CompanyId, RemoveCompanyCommand command)
    {
        try
        {
            command.Id = CompanyId;

            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Remove Company request completed successfully!"
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
