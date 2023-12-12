using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands;

public sealed record DeleteUserCommand : BaseCommand
{
    public bool IsDeleted { get; set; }
}
