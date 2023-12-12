using CQRS.Core.Events;

namespace Brete.Common.Events.User;

public sealed record UserUpdatedEvent : BaseEvent
{
    public UserUpdatedEvent() : base(nameof(UserUpdatedEvent))
    {
    }
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

}
