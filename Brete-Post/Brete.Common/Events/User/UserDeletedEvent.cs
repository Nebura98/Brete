using CQRS.Core.Events;

namespace Brete.Common.Events.User;

public sealed record UserDeletedEvent : BaseEvent
{
    public UserDeletedEvent() : base(nameof(UserDeletedEvent))
    {
    }
    public bool IsDeleted { get; set; }
}
