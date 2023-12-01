using CQRS.Core.Events;

namespace Brete.Common.Events.User;

public sealed record UserCreatedEvent : BaseEvent
{
    public UserCreatedEvent() : base(nameof(UserCreatedEvent))
    {
    }
    public required string FullName { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PhoneNumber { get; set; }
}
