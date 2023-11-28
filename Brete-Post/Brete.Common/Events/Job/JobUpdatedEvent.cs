using CQRS.Core.Events;

namespace Brete.Common.Events.Job;

public sealed record JobUpdatedEvent : BaseEvent
{
    public JobUpdatedEvent() : base(nameof(JobUpdatedEvent)) { }

    public string Title { get; set; }
    public string Description { get; set; }
    public List<string>? Skills { get; set; }
    public decimal Salary { get; set; }
    public string Seniority { get; set; }
    public string Modality { get; set; }
    public bool IsOpen { get; set; }
    public bool IsDeleted { get; set; }
}
