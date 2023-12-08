using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands.Skill;

public record DisableSkillCommand : BaseCommand
{
    public bool IsActive { get; set; }
}
