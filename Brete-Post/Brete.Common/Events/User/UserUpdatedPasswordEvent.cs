using CQRS.Core.Events;

namespace Brete.Common.Events.User;

public sealed record UserUpdatedPasswordEvent : BaseEvent
{
    public UserUpdatedPasswordEvent() : base(nameof(UserUpdatedPasswordEvent))
    {
    }
    public required string NewPassword { get; set; }
}
