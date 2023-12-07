using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands.Job;

public record DeleteJobCommand : BaseCommand
{
    public bool IsDeleted { get; set; }
}
