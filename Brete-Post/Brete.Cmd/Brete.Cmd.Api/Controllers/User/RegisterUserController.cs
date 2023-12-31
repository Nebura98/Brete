﻿using Brete.Cmd.Api.Commands.User;
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
        _logger = logger;
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUserAsync(CreateUserCommand command)
    {
        try
        {
            await _commandDispatcher.SendAsync(command);

            return Ok(new BaseResponse
            {
                Message = "Add User request completed successfully!"
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
