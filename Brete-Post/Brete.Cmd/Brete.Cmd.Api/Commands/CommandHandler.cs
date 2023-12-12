using Brete.Cmd.Api.Commands.Company;
using Brete.Cmd.Api.Commands.Job;
using Brete.Cmd.Api.Commands.Skill;
using Brete.Cmd.Api.Commands.User;
using Brete.Cmd.Domain.Aggregates.CompanyAggregate;
using Brete.Cmd.Domain.Aggregates.JobAggregate;
using Brete.Cmd.Domain.Aggregates.SkillAggregate;
using Brete.Cmd.Domain.Aggregates.UserAggregate;
using CQRS.Core.Handlers;

namespace Brete.Cmd.Api.Commands;

public class CommandHandler : ICommandHandler
{
    private readonly IEventSourcingHandler<CompanyAggregate> _companyEventSourcingHandler;
    private readonly IEventSourcingHandler<JobAggregate> _jobEventSourcingHandler;
    private readonly IEventSourcingHandler<SkillAggregate> _skillEventSourcingHandler;
    private readonly IEventSourcingHandler<UserAggregate> _userEventSourcingHandler;

    public CommandHandler(
        IEventSourcingHandler<JobAggregate> eventSourcingHandler,
        IEventSourcingHandler<SkillAggregate> skillEventSourcingHandler,
        IEventSourcingHandler<CompanyAggregate> companyEventSourcingHandler,
        IEventSourcingHandler<UserAggregate> userEventSourcingHandler)
    {
        _jobEventSourcingHandler = eventSourcingHandler;
        _skillEventSourcingHandler = skillEventSourcingHandler;
        _companyEventSourcingHandler = companyEventSourcingHandler;
        _userEventSourcingHandler = userEventSourcingHandler;
    }


    public async Task HandleAsync(CreateCompanyCommand command)
    {
        var aggregate = new CompanyAggregate(command.Id,
                                             command.Name,
                                             command.LegalName,
                                             command.Address,
                                             command.Phone,
                                             command.Email,
                                             command.Website,
                                             command.Industry,
                                             command.Size,
                                             command.FoundingDate);

        await _companyEventSourcingHandler.SaveAsync(aggregate);
    }

    public async Task HandleAsync(UpdateCompanyCommand command)
    {
        var aggregate = await _companyEventSourcingHandler.GetByIdAsync(command.Id);

        aggregate.UpdateCompany(command.Id,
                                command.Name,
                                command.LegalName,
                                command.Address,
                                command.Phone,
                                command.Email,
                                command.Website,
                                command.Industry,
                                command.Size,
                                command.FoundingDate);

        await _companyEventSourcingHandler.SaveAsync(aggregate);
    }

    public async Task HandleAsync(DisableCompanyCommand command)
    {
        var aggregate = await _companyEventSourcingHandler.GetByIdAsync(command.Id);
        aggregate.DisableCompany(command.Id, command.IsActive);

        await _companyEventSourcingHandler.SaveAsync(aggregate);
    }

    public async Task HandleAsync(DeleteCompanyCommand command)
    {
        var aggregate = await _companyEventSourcingHandler.GetByIdAsync(command.Id);

        aggregate.DeleteCompany(command.Id, command.IsDeleted);

        await _companyEventSourcingHandler.SaveAsync(aggregate);

    }

    public async Task HandleAsync(CreateJobCommand command)
    {
        var aggregate = new JobAggregate(command.Id,
                                         command.CompanyId,
                                         command.Title,
                                         command.Description,
                                         command.Skills,
                                         command.Salary,
                                         command.Seniority,
                                         command.Modality);

        await _jobEventSourcingHandler.SaveAsync(aggregate);
    }

    public async Task HandleAsync(UpdateJobCommand command)
    {
        var aggregate = await _jobEventSourcingHandler.GetByIdAsync(command.Id);
        aggregate.EditJob(command.Id,
                          command.Title,
                          command.Description,
                          command.Skills,
                          command.Salary,
                          command.Seniority,
                          command.Modality);

        await _jobEventSourcingHandler.SaveAsync(aggregate);
    }

    public async Task HandleAsync(DisableJobCommand command)
    {
        var aggregate = await _jobEventSourcingHandler.GetByIdAsync(command.Id);
        aggregate.ChangeStateJob(command.Id, command.IsOpen);

        await _jobEventSourcingHandler.SaveAsync(aggregate);
    }

    public async Task HandleAsync(DeleteJobCommand command)
    {
        var aggregate = await _jobEventSourcingHandler.GetByIdAsync(command.Id);
        aggregate.DeleteJob(command.Id, command.IsDeleted);

        await _jobEventSourcingHandler.SaveAsync(aggregate);
    }

    public async Task HandleAsync(RemoveJobCommand command)
    {
        var aggregate = await _jobEventSourcingHandler.GetByIdAsync(command.Id);
        aggregate.RemoveJob(command.Id);

        await _jobEventSourcingHandler.SaveAsync(aggregate);
    }


    //For Skill
    public async Task HandleAsync(CreateSkillCommand command)
    {
        var aggregate = new SkillAggregate(command.Id,
                                           command.Name,
                                           command.Description,
                                           command.Section);

        await _skillEventSourcingHandler.SaveAsync(aggregate);
    }

    public async Task HandleAsync(UpdateSkillCommand command)
    {
        var aggregate = await _skillEventSourcingHandler.GetByIdAsync(command.Id);
        aggregate.UpdateSkill(command.Id, command.Name, command.Description, command.Section);

        await _skillEventSourcingHandler.SaveAsync(aggregate);
    }

    public async Task HandleAsync(DisableSkillCommand command)
    {
        var aggregate = await _skillEventSourcingHandler.GetByIdAsync(command.Id);
        aggregate.SwitchStateSkill(command.Id, command.IsActive);

        await _skillEventSourcingHandler.SaveAsync(aggregate);
    }

    public async Task HandleAsync(DeleteSkillCommand command)
    {
        var aggregate = await _skillEventSourcingHandler.GetByIdAsync(command.Id);
        aggregate.DeletedSkill(command.Id, command.IsDeleted);

        await _skillEventSourcingHandler.SaveAsync(aggregate);
    }

    public async Task HandleAsync(CreateUserCommand command)
    {
        var aggregate = new UserAggregate(command.Id,
                                          command.FullName,
                                          command.UserName,
                                          command.Email,
                                          command.PhoneNumber,
                                          command.Password);

        await _userEventSourcingHandler.SaveAsync(aggregate);
    }

    public Task HandleAsync(UpdateUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task HandleAsync(DisableUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task HandleAsync(DeleteUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task HandleAsync(UpdatePasswordUserCommand command)
    {
        throw new NotImplementedException();
    }
}
