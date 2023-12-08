using CQRS.Core.Events;

namespace Brete.Common.Events.Skill;

public sealed record SkillDeletedEvent : BaseEvent
{
    public SkillDeletedEvent() : base(nameof(SkillDeletedEvent))
    {
    }

    public bool IsDeleted { get; set; }
}
