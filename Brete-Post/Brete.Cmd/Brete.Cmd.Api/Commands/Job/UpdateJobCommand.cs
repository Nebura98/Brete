using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands.Job;

public record UpdateJobCommand : BaseCommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Guid>? Skills { get; set; }
    public decimal Salary { get; set; }
    public string Seniority { get; set; }
    public string Modality { get; set; }
}
