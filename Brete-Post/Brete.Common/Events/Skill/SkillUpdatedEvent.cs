using CQRS.Core.Events;

namespace Brete.Common.Events.Skill;

public sealed record SkillUpdatedEvent : BaseEvent
{
    public SkillUpdatedEvent() : base(nameof(SkillUpdatedEvent))
    {
    }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Section { get; set; }
}
