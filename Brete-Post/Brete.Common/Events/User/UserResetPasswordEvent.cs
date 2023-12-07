using CQRS.Core.Events;

namespace Brete.Common.Events.User;

public sealed record UserResetPasswordEvent : BaseEvent
{
    public UserResetPasswordEvent() : base(nameof(UserResetPasswordEvent))
    {
    }
    public required string NewPassword { get; set; }

}