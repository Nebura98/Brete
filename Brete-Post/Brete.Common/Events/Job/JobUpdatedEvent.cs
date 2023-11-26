using CQRS.Core.Events;

namespace Brete.Common.Events.Job;

public sealed record JobUpdatedEvent : BaseEvent
{
    public JobUpdatedEvent() : base(nameof(JobUpdatedEvent)) { }

    public required Guid JobId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string>? Skills { get; set; }
    public string Salary { get; set; }
    public string Seniority { get; set; }
    public string Modality { get; set; }
    public bool IsOpen { get; set; }
    public bool IsDeleted { get; set; }
}
