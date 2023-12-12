using Brete.Cmd.Api.Commands.Company;
using Brete.Cmd.Api.Commands.Job;
using Brete.Cmd.Api.Commands.Skill;
using Brete.Cmd.Api.Commands.User;

namespace Brete.Cmd.Api.Commands;

public interface ICommandHandler
{

    Task HandleAsync(CreateCompanyCommand command);
    Task HandleAsync(UpdateCompanyCommand command);
    Task HandleAsync(DisableCompanyCommand command);
    Task HandleAsync(DeleteCompanyCommand command);
    Task HandleAsync(CreateJobCommand command);
    Task HandleAsync(UpdateJobCommand command);
    Task HandleAsync(DisableJobCommand command);
    Task HandleAsync(DeleteJobCommand command);
    Task HandleAsync(RemoveJobCommand command);
    Task HandleAsync(CreateSkillCommand command);
    Task HandleAsync(UpdateSkillCommand command);
    Task HandleAsync(DisableSkillCommand command);
    Task HandleAsync(DeleteSkillCommand command);
    Task HandleAsync(CreateUserCommand command);
    Task HandleAsync(UpdateUserCommand command);
    Task HandleAsync(DisableUserCommand command);
    Task HandleAsync(DeleteUserCommand command);
    Task HandleAsync(UpdatePasswordUserCommand command);
}
