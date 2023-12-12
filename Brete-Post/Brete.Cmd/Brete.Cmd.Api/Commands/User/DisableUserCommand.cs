using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands;

public sealed record DisableUserCommand : BaseCommand
{
    public required bool IsDisable { get; set; }
}
