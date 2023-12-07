using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands.Job;

public record DisableJobCommand : BaseCommand
{
    public bool IsOpen { get; set; }
}
