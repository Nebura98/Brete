using CQRS.Core.Events;

namespace Brete.Common.Events.Job;

public sealed record JobCreatedEvent : BaseEvent
{
    public JobCreatedEvent() : base(nameof(JobCreatedEvent)) { }

    public required Guid CompanyId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public IReadOnlyList<string>? Skills { get; set; }
    public required decimal Salary { get; set; }
    public required string Seniority { get; set; }
    public required string Modality { get; set; }
    public bool IsOpen { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
}
