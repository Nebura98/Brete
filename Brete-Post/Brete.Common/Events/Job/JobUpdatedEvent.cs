using CQRS.Core.Events;

namespace Brete.Common.Events.Job;

public sealed record JobUpdatedEvent : BaseEvent
{
    public JobUpdatedEvent() : base(nameof(JobUpdatedEvent)) { }

    public required Guid JobId { get; set; }
    public required Guid CompanyId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public List<Guid> Skills { get; set; }
    public required decimal Salary { get; set; }
    public required byte Seniority { get; set; }
    public required byte Modality { get; set; }
    public bool IsOpen { get; set; }
    public bool IsDeleted { get; set; }
}
