using Brete.Common.Events.Company;
using Brete.Common.Events.Job;
using Brete.Common.Events.Skill;
using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;

namespace Brete.Query.Infrastructure.Handlers;

public class EventHandler : IEventHandler
{
    private readonly ICompanyRepository _cacheCompanyRepository;
    private readonly IJobRepository _jobRepository;
    private readonly ISkillRepository _cacheSkillRepository;

    public EventHandler(IJobRepository jobRepository,
                        ISkillRepository cacheSkillRepository,
                        ICompanyRepository cacheCompanyRepository)
    {
        _jobRepository = jobRepository;
        _cacheSkillRepository = cacheSkillRepository;
        _cacheCompanyRepository = cacheCompanyRepository;
    }

    //Company
    public async Task On(CompanyCreatedEvent @event)
    {
        var company = new CompanyEntity
        {
            Id = @event.Id,
            Name = @event.Name,
            LegalName = @event.LegalName,
            Address = @event.Address,
            Phone = @event.Phone,
            Email = @event.Email,
            Website = @event.Website,
            Industry = @event.Industry,
            Size = @event.Size,
            FoundingDate = DateTime.UtcNow,
        };

        await _cacheCompanyRepository.CreateAsync(company);
    }

    public Task On(CompanyDisableEvent @event)
    {
        throw new NotImplementedException();
    }

    public Task On(CompanyUpdatedEvent @event)
    {
        throw new NotImplementedException();
    }

    public Task On(CompanyDeletedEvent @event)
    {
        throw new NotImplementedException();
    }

    //Job
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

        await _cacheSkillRepository.CreateAsync(skill);
    }

    public async Task On(SkillUpdatedEvent @event)
    {
        var skill = await _cacheSkillRepository.GetByIdAsync(@event.Id);

        if (skill == null) return;

        skill.Name = @event.Name;
        skill.Description = @event.Description;
        skill.Section = @event.Section;
        skill.UpdatedAt = DateTime.UtcNow;

        await _cacheSkillRepository.UpdateAsync(skill);
    }

    public async Task On(SkillDisableEvent @event)
    {
        var skill = await _cacheSkillRepository.GetByIdAsync(@event.Id);

        if (skill == null) return;

        skill.IsActive = @event.IsDisable;

        await _cacheSkillRepository.DisableAsync(skill);
    }

    public async Task On(SkillDeletedEvent @event)
    {
        var skill = await _cacheSkillRepository.GetByIdAsync(@event.Id);

        if (skill == null) return;

        skill.IsDeleted = @event.IsDeleted;

        await _cacheSkillRepository.DeleteAsync(skill);
    }
}
