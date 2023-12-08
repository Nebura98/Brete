using Brete.Cmd.Api.Commands.Job;
using Brete.Cmd.Api.Commands.Skill;

namespace Brete.Cmd.Api.Commands;

public interface ICommandHandler
{

    //Task HandleAsync(CreateCompanyCommand command);
    //Task HandleAsync(UpdateCompanyCommand command);
    //Task HandleAsync(DisableCompanyCommand command);
    //Task HandleAsync(RemoveCompanyCommand command);
    Task HandleAsync(CreateJobCommand command);
    Task HandleAsync(UpdateJobCommand command);
    Task HandleAsync(DisableJobCommand command);
    Task HandleAsync(DeleteJobCommand command);
    Task HandleAsync(RemoveJobCommand command);
    Task HandleAsync(CreateSkillCommand command);
    Task HandleAsync(UpdateSkillCommand command);
    Task HandleAsync(DisableSkillCommand command);
    Task HandleAsync(DeleteSkillCommand command);
}
