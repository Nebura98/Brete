using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands.Skill;

public record DeleteSkillCommand : BaseCommand
{
    public bool IsDeleted { get; set; }
}
