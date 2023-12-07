using CQRS.Core.Events;

namespace Brete.Common.Events.Skill;

public sealed record SkillDisableEvent : BaseEvent
{
    public SkillDisableEvent() : base(nameof(SkillDisableEvent))
    {
    }

    public required bool IsDisable { get; set; }
}
