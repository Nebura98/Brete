using CQRS.Core.Events;

namespace Brete.Common.Events.Skill;

public sealed record SkillSwitchStateEvent : BaseEvent
{
    public SkillSwitchStateEvent() : base(nameof(SkillSwitchStateEvent))
    {
    }

    public required bool IsDisable { get; set; }
}
