using Brete.Cmd.Api.Commands.Job;
using Brete.Cmd.Api.Commands.Skill;
using Brete.Cmd.Domain.Aggregates.JobAggregate;
using Brete.Cmd.Domain.Aggregates.SkillAggregate;
using CQRS.Core.Handlers;

namespace Brete.Cmd.Api.Commands;

public class CommandHandler : ICommandHandler
{
    //private readonly IEventSourcingHandler<CompanyAggregate> _companyEventSourcingHandler;
    private readonly IEventSourcingHandler<JobAggregate> _jobEventSourcingHandler;
    private readonly IEventSourcingHandler<SkillAggregate> _skillEventSourcingHandler;
    public CommandHandler(IEventSourcingHandler<JobAggregate> eventSourcingHandler,
                          IEventSourcingHandler<SkillAggregate> skillEventSourcingHandler)
    {
        _jobEventSourcingHandler = eventSourcingHandler;
        _skillEventSourcingHandler = skillEventSourcingHandler;
    }


    //public Task HandleAsync(CreateCompanyCommand command)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task HandleAsync(UpdateCompanyCommand command)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task HandleAsync(DisableCompanyCommand command)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task HandleAsync(RemoveCompanyCommand command)
    //{
    //    throw new NotImplementedException();
    //}

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
}
