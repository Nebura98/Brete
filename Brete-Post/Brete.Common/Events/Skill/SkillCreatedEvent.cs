using CQRS.Core.Events;

namespace Brete.Common.Events.Skill;

public sealed record SkillCreatedEvent : BaseEvent
{
    public SkillCreatedEvent() : base(nameof(SkillCreatedEvent))
    {
    }

    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Section { get; set; }
    public bool IsDisable { get; set; } = true;
}
