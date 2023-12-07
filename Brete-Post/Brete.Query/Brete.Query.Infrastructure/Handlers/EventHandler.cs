using Brete.Common.Events.Job;
using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;

namespace Brete.Query.Infrastructure.Handlers;

public class EventHandler : IEventHandler
{
    private readonly IJobRepository _jobRepository;

    public EventHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
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

        await _jobRepository.UpdateAsync(job);
    }

    public async Task On(JobDisableEvent @event)
    {
        var job = await _jobRepository.GetByIdAsync(@event.Id);

        if (job == null) return;

        job.IsActive = @event.IsOpen;
        job.IsEdited = true;

        await _jobRepository.UpdateAsync(job);
    }

    public async Task On(JobDeletedEvent @event)
    {
        var job = await _jobRepository.GetByIdAsync(@event.Id);

        if (job == null) return;

        job.IsDeleted = true;

        await _jobRepository.UpdateAsync(job);
    }
}
