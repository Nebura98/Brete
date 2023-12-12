using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands.User;

public record CreateUserCommand : BaseCommand
{
    public required string FullName { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PhoneNumber { get; set; }
}
