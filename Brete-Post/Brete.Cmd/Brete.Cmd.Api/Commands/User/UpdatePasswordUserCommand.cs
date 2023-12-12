using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands;

public sealed record UpdatePasswordUserCommand : BaseCommand
{
    public required string OldPassword { get; set; }
    public required string NewPassword { get; set; }
}
