using Brete.Common.Events.Company;
using Brete.Common.Events.Job;
using Brete.Common.Events.Skill;
using Brete.Common.Events.User;
using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using BC = BCrypt.Net.BCrypt;



namespace Brete.Query.Infrastructure.Handlers;

public class EventHandler : IEventHandler
{
    private readonly ICompanyRepository _cacheCompanyRepository;
    private readonly IJobRepository _jobRepository;
    private readonly ISkillRepository _cacheSkillRepository;
    private readonly IUserRepository _userRepository;

    public EventHandler(
        IJobRepository jobRepository,
        ISkillRepository cacheSkillRepository,
        ICompanyRepository cacheCompanyRepository,
        IUserRepository userRepository)
    {
        _jobRepository = jobRepository;
        _cacheSkillRepository = cacheSkillRepository;
        _cacheCompanyRepository = cacheCompanyRepository;
        _userRepository = userRepository;
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

    public async Task On(CompanyUpdatedEvent @event)
    {
        var company = await _cacheCompanyRepository.GetByIdAsync(@event.Id);

        if (company is null) return;

        company.Name = @event.Name;
        company.LegalName = @event.LegalName;
        company.Address = @event.Address;
        company.Phone = @event.Phone;
        company.Email = @event.Email;
        company.Website = @event.Website;
        company.Industry = @event.Industry;
        company.Size = @event.Size;
        company.FoundingDate = DateTime.UtcNow;

        await _cacheCompanyRepository.UpdateAsync(company);
    }

    public async Task On(CompanyDisableEvent @event)
    {
        var company = await _cacheCompanyRepository.GetByIdAsync(@event.Id);

        if (company is null) return;

        company.IsActive = @event.IsActive;

        await _cacheCompanyRepository.DisableAsync(company);
    }

    public async Task On(CompanyDeletedEvent @event)
    {
        var company = await _cacheCompanyRepository.GetByIdAsync(@event.Id);

        if (company is null) return;

        company.IsDeleted = @event.IsDeleted;

        await _cacheCompanyRepository.DeleteAsync(company);
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

        if (job is null) return;

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

        if (job is null) return;

        job.IsActive = @event.IsOpen;

        await _jobRepository.UpdateAsync(job);
    }

    public async Task On(JobDeletedEvent @event)
    {
        var job = await _jobRepository.GetByIdAsync(@event.Id);

        if (job is null) return;

        job.IsDeleted = true;

        await _jobRepository.UpdateAsync(job);
    }

    public async Task On(JobRemovedEvent @event)
    {
        var job = await _jobRepository.GetByIdAsync(@event.Id);

        if (job is null) return;

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

        if (skill is null) return;

        skill.Name = @event.Name;
        skill.Description = @event.Description;
        skill.Section = @event.Section;
        skill.UpdatedAt = DateTime.UtcNow;

        await _cacheSkillRepository.UpdateAsync(skill);
    }

    public async Task On(SkillDisableEvent @event)
    {
        var skill = await _cacheSkillRepository.GetByIdAsync(@event.Id);

        if (skill is null) return;

        skill.IsActive = @event.IsDisable;

        await _cacheSkillRepository.DisableAsync(skill);
    }

    public async Task On(SkillDeletedEvent @event)
    {
        var skill = await _cacheSkillRepository.GetByIdAsync(@event.Id);

        if (skill is null) return;

        skill.IsDeleted = @event.IsDeleted;

        await _cacheSkillRepository.DeleteAsync(skill);
    }

    public async Task On(UserCreatedEvent @event)
    {
        var hashedPassword = BC.HashPassword(@event.Password, workFactor: 10);

        var user = new UserEntity
        {
            Id = @event.Id,
            FullName = @event.FullName,
            UserName = @event.UserName,
            Email = @event.Email,
            Password = hashedPassword,
            PhoneNumber = @event.PhoneNumber
        };

        await _userRepository.CreateAsync(user);
    }

    public async Task On(UserUpdatedEvent @event)
    {
    }

    public async Task On(UserUpdatedPasswordEvent @event)
    {
    }
    public async Task On(UserDisableEvent @event)
    {
    }
    public async Task On(UserDeletedEvent @event)
    {
    }
}
