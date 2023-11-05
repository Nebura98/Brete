using CQRS.Core.Events;

namespace Brete.Common.Events.Job;

public sealed record JobDeletedEvent : BaseEvent
{
    public JobDeletedEvent() : base(nameof(JobDeletedEvent))
    {
    }

    public required Guid JobId { get; set; }
    public bool IsDeleted { get; set; }
}