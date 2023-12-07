using Brete.Common.Events.Job;
using CQRS.Core.Domain;


namespace Brete.Cmd.Domain.Aggregates.JobAggregate;

public sealed class JobAggregate : AggregateRoot
{
    private Guid _companyId;
    private bool _isOpen;
    private bool _isDeleted;
    private bool _active;

    public Guid CompanyId { get => _companyId; set => _companyId = value; }
    public bool IsDeleted { get => _isDeleted; set => _isDeleted = value; }
    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    public bool Active { get => _active; set => _active = value; }

    public JobAggregate()
    {
    }

    //Add new job event
    public JobAggregate(Guid jobId, Guid companyId, string title, string description, ICollection<Guid> skills, decimal salary, string seniority, string modality)
    {
        RaiseEvent(new JobCreatedEvent
        {
            Id = jobId,
            CompanyId = companyId,
            Title = title,
            Slug = $"{title.Trim().ToLowerInvariant().Replace(" ", "-")}-{jobId}",
            Description = description,
            Skills = skills,
            Salary = salary,
            Seniority = seniority,
            Modality = modality,
        });
    }

    public void Apply(JobCreatedEvent @event)
    {
        _id = @event.Id;
        _companyId = @event.CompanyId;
    }


    //Edit job
    public void EditJob(Guid jobId, string title, string description, List<Guid> skills, decimal salary, string seniority, string modality)
    {
        RaiseEvent(new JobUpdatedEvent
        {
            Id = jobId,
            Title = title,
            Slug = $"{title.Trim().ToLowerInvariant().Replace(" ", "-")}-{jobId}",
            Description = description,
            Skills = skills,
            Salary = salary,
            Seniority = seniority,
            Modality = modality,
        });
    }

    public void Apply(JobUpdatedEvent @event)
    {
        _id = @event.Id;
    }

    //Change state of the job open or close
    public void ChangeStateJob(Guid jobId, bool isOpen)
    {
        RaiseEvent(new JobDisableEvent
        {
            Id = jobId,
            IsOpen = isOpen,
        });
    }


    public void Apply(JobDisableEvent @event)
    {
        _id = @event.Id;
    }

    //delete of the job open or close
    public void DeleteJob(Guid jobId, bool isDeleted)
    {
        RaiseEvent(new JobDeletedEvent
        {
            Id = jobId,
            IsDeleted = isDeleted,
        });
    }


    public void Apply(JobDeletedEvent @event)
    {
        _id = @event.Id;
        _isDeleted = @event.IsDeleted;
    }

    //Remove job 
    public void RemoveJob(Guid JobId)
    {
        RaiseEvent(new JobRemovedEvent
        {
            Id = JobId
        });
    }

    public void Apply(JobRemovedEvent @event)
    {
        _id = @event.Id;
    }
}