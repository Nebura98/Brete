using CQRS.Core.Events;

namespace Brete.Cmd.Domain.Aggregates.UserAggregate;

public sealed record UserResetPasswordEvent : BaseEvent
{
    public UserResetPasswordEvent() : base(nameof(UserResetPasswordEvent))
    {
    }
    public required string NewPassword { get; set; }

}