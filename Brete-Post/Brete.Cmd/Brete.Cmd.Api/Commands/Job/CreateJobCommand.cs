using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands.Job;

public record CreateJobCommand : BaseCommand
{
    public required Guid CompanyId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public IReadOnlyList<string>? Skills { get; set; }
    public required string Salary { get; set; }
    public required string Seniority { get; set; }
    public required string Modality { get; set; }
}
