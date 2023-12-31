﻿using Brete.Common.Events.Skill;
using CQRS.Core.Domain;

namespace Brete.Cmd.Domain.Aggregates.SkillAggregate;

public sealed class SkillAggregate : AggregateRoot
{
    private bool _active;
    public bool Active { get => _active; set => _active = value; }

    public SkillAggregate()
    {
    }

    public SkillAggregate(Guid SkillId, string name, string description, string section)
    {

        RaiseEvent(new SkillCreatedEvent
        {
            Id = SkillId,
            Name = name,
            Description = description,
            Section = section
        });
    }

    public void Apply(SkillCreatedEvent @event)
    {
        _id = @event.Id;
    }

    public void UpdateSkill(Guid SkillId, string name, string description, string section)
    {
        RaiseEvent(new SkillUpdatedEvent
        {
            Id = SkillId,
            Name = name,
            Description = description,
            Section = section,
        });
    }

    public void Apply(SkillUpdatedEvent @event)
    {
        _id = @event.Id;
    }

    public void SwitchStateSkill(Guid SkillId, bool isDisable)
    {
        RaiseEvent(new SkillDisableEvent
        {
            Id = SkillId,
            IsDisable = isDisable
        });
    }

    public void Apply(SkillDisableEvent @event)
    {
        _id = @event.Id;
    }

    public void DeletedSkill(Guid SkillId, bool isDeleted)
    {
        RaiseEvent(new SkillDeletedEvent
        {
            Id = SkillId,
            IsDeleted = isDeleted
        });
    }

    public void Apply(SkillDeletedEvent @event)
    {
        _id = @event.Id;
    }
}
