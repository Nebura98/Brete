using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands.Skill;

public record CreateSkillCommand : BaseCommand
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Section { get; set; }
}
