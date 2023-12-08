using Brete.Common.Events.Job;
using Brete.Common.Events.Skill;
using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;

namespace Brete.Query.Infrastructure.Handlers;

public class EventHandler : IEventHandler
{
    private readonly IJobRepository _jobRepository;
    private readonly ISkillRepository _skillRepository;

    public EventHandler(IJobRepository jobRepository, ISkillRepository skillRepository)
    {
        _jobRepository = jobRepository;
        _skillRepository = skillRepository;
    }

    public async Task On(JobCreatedEvent @event)
    {
        var job = new JobEntity
        {
            Id = @event.Id,
            CompanyId = @event.CompanyId,
            Title = @event.Title,
            Slug = @event.Slug,
            Description = @event.Description,
            Salary = @event.Salary,
            Seniority = @event.Seniority,
            Modality = @event.Modality,
            IsDeleted = @event.IsDeleted,
        };

        await _jobRepository.CreateAsync(job);
    }

    public async Task On(JobUpdatedEvent @event)
    {
        var job = await _jobRepository.GetByIdAsync(@event.Id);

        if (job == null) return;

        job.Title = @event.Title;
        job.Slug = @event.Slug;
        job.Description = @event.Description;
        job.Salary = @event.Salary;
        job.Seniority = @event.Seniority;
        job.Modality = @event.Modality;
        job.IsEdited = true;
        job.UpdatedAt = DateTime.UtcNow;

        await _jobRepository.UpdateAsync(job);
    }

    public async Task On(JobDisableEvent @event)
    {
        var job = await _jobRepository.GetByIdAsync(@event.Id);

        if (job == null) return;

        job.IsActive = @event.IsOpen;

        await _jobRepository.UpdateAsync(job);
    }

    public async Task On(JobDeletedEvent @event)
    {
        var job = await _jobRepository.GetByIdAsync(@event.Id);

        if (job == null) return;

        job.IsDeleted = true;

        await _jobRepository.UpdateAsync(job);
    }

    public async Task On(JobRemovedEvent @event)
    {
        var job = await _jobRepository.GetByIdAsync(@event.Id);

        if (job == null) return;

        await _jobRepository.RemoveAsync(job);
    }

    //For Skill entity
    public async Task On(SkillCreatedEvent @event)
    {
        var skill = new SkillEntity
        {
            Id = @event.Id,
            Name = @event.Name,
            Description = @event.Description,
            Section = @event.Section
        };

        await _skillRepository.CreateAsync(skill);
    }

    public async Task On(SkillUpdatedEvent @event)
    {
        var skill = await _skillRepository.GetByIdAsync(@event.Id);

        if (skill == null) return;

        skill.Name = @event.Name;
        skill.Description = @event.Description;
        skill.Section = @event.Section;
        skill.UpdatedAt = DateTime.UtcNow;

        await _skillRepository.UpdateAsync(skill);
    }

    public async Task On(SkillDisableEvent @event)
    {
        var skill = await _skillRepository.GetByIdAsync(@event.Id);

        if (skill == null) return;

        skill.IsActive = @event.IsDisable;

        await _skillRepository.DisableAsync(skill);
    }

    public async Task On(SkillDeletedEvent @event)
    {
        var skill = await _skillRepository.GetByIdAsync(@event.Id);

        if (skill == null) return;

        skill.IsDeleted = @event.IsDeleted;

        await _skillRepository.DeleteAsync(skill);
    }

}
