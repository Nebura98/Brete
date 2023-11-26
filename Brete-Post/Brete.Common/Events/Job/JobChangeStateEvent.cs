using CQRS.Core.Events;

namespace Brete.Common.Events.Job;

public sealed record JobChangeStateEvent : BaseEvent
{
    public JobChangeStateEvent() : base(nameof(JobChangeStateEvent)) { }

    public required Guid JobId { get; set; }
    public required Guid CompanyId { get; set; }
    public required bool IsOpen { get; set; }
}
