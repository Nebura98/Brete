using Brete.Query.Api.Dtos;
using Brete.Query.Api.Queries.User;
using Brete.Query.Domain.Entities;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;

namespace Brete.Query.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserLookupController : Controller
{
    private readonly ILogger<UserLookupController> _logger;
    private readonly IQueryDispatcher<UserEntity> _queryDispatcher;

    public UserLookupController(ILogger<UserLookupController> logger, IQueryDispatcher<UserEntity> queryDispatcher)
    {
        _logger = logger;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllUser()
    {

        try
        {
            var users = await _queryDispatcher.SendAsync(new FindAllUsersQuery());
            return NormalResponse(users);
        }
        catch (Exception ex)
        {
            const string SAFE_ERROR_MESSAGE = "Error while processing request to retrieve all posts!";
            return ErrorResponse(ex, SAFE_ERROR_MESSAGE);
        }
    }



    private ActionResult NormalResponse(List<UserEntity> users)
    {
        if (users is null || !users.Any())
            return NoContent();

        var count = users.Count;

        return Ok(new UserLookupResponse
        {
            Users = users,
            Message = $"Successfully returned {count} user{(count > 1 ? "s" : string.Empty)}!"
        });
    }

    private ActionResult ErrorResponse(Exception ex, string safeErrorMessage)
    {
        _logger.LogError(ex, safeErrorMessage);

        return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
        {
            Message = safeErrorMessage
        });
    }

}
