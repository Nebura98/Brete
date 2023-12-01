using CQRS.Core.Events;

namespace Brete.Common.Events.User;

public sealed record UserSwitchedEvent : BaseEvent
{
    public UserSwitchedEvent() : base(nameof(UserSwitchedEvent))
    {
    }
    public required bool IsDisable { get; set; }
}
