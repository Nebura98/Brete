using Brete.Cmd.Api.Commands.Company;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Company;

[Route("api/[controller]")]
[ApiController]
public class DeleteCompanyController : ControllerBase
{
    private readonly ILogger<DeleteCompanyController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public DeleteCompanyController(ICommandDispatcher commandDispatcher, ILogger<DeleteCompanyController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCompanyAsync(Guid id, DeleteCompanyCommand command)
    {
        try
        {
            command.Id = id;

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
