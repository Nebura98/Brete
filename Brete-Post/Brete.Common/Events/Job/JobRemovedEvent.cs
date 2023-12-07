using CQRS.Core.Events;

namespace Brete.Common.Events.Job;

public sealed record JobRemovedEvent : BaseEvent
{
    public JobRemovedEvent() : base(nameof(JobRemovedEvent)) { }
}
