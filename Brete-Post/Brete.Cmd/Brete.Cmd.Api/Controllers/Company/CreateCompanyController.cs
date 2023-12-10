using Brete.Cmd.Api.Commands.Company;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Cmd.Api.Controllers.Company;

[Route("api/[controller]")]
[ApiController]
public class CreateCompanyController : ControllerBase
{
    private readonly ILogger<CreateCompanyController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public CreateCompanyController(ICommandDispatcher commandDispatcher, ILogger<CreateCompanyController> logger)
    {
        _commandDispatcher = commandDispatcher;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompanyAsync(CreateCompanyCommand command)
    {
        try
        {

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
