using CQRS.Core.Events;

namespace Brete.Common.Events.User;

public sealed record UserDisableEvent : BaseEvent
{
    public UserDisableEvent() : base(nameof(UserDisableEvent))
    {
    }
    public required bool IsDisable { get; set; }
}
