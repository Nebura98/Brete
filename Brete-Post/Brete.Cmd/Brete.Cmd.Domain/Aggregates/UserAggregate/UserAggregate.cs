﻿using Brete.Common.Events.User;
using CQRS.Core.Domain;

namespace Brete.Cmd.Domain.Aggregates.UserAggregate;

public sealed class UserAggregate : AggregateRoot
{
    public UserAggregate(string fullName, string userName, string email, string phoneNumber, string password)
    {
        RaiseEvent(new UserCreatedEvent
        {
            FullName = fullName,
            UserName = userName,
            Email = email,
            Password = password,
            PhoneNumber = phoneNumber,
        });
    }

    public void Apply(UserCreatedEvent @event)
    {
    }

    public void UpdatedUser(string fullName, string userName, string email, string phoneNumber)
    {
        RaiseEvent(new UserUpdatedEvent
        {
            FullName = fullName,
            UserName = userName,
            Email = email,
            PhoneNumber = phoneNumber,
        });
    }

    public void Apply(UserUpdatedEvent @event) { }

    public void UpdatedUserSwitched() { }

    public void Apply(UserSwitchedEvent @event) { }

    public void UpdatedPassword() { }

    public void Apply(UserUpdatedPasswordEvent @event) { }

    public void DeletedUser(UserDeletedEvent @event) { }

    public void Apply(UserDeletedEvent @event) { }

    public void ResetPassword() { }

    public void Apply(UserResetPasswordEvent @event) { }

}
