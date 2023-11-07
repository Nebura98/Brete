using Brete.Common.Events.Job;
using CQRS.Core.Domain;
using CQRS.Core.Domain.ValueObject;

namespace Brete.Cmd.Domain.Aggregates.JobAggregate;

public sealed class JobAggregate: AggregateRoot
{
    private bool _isDeleted = false;
    private bool _isOpen    = false;
    private Guid _companyId;

    public bool IsDeleted { get => _isDeleted; set => _isDeleted = value; }
    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    public Guid CompanyId { get => _companyId; set => _companyId = value; }

    public JobAggregate()
    {
    }

      //Add new job event
    public JobAggregate(Guid jobId, Guid companyId, string title, string description, decimal salary, byte seniority, byte modality)
    {
        RaiseEvent(new JobCreatedEvent
        {
            Id          = jobId,
            Title       = title,
            CompanyId   = companyId,
            Description = description,
            Salary      = salary,
            Seniority   = seniority,
            Modality    = modality,
        });
    }

    public void Apply(JobCreatedEvent @event)
    {
        _id        = @event.Id;
        _companyId = @event.CompanyId;
    }


      //Edit job
    public void EditJob(Guid jobId, string title, Guid companyId, string description, List<Guid> skills, decimal salary, byte seniority, byte modality)
    {        
        RaiseEvent(new JobUpdatedEvent
        {
            JobId       = jobId,
            Title       = title,
            CompanyId   = companyId,
            Description = description,
            Skills      = skills,
            Salary      = salary,
            Seniority   = seniority,
            Modality    = modality,
        });
    }

    public void Apply(JobUpdatedEvent @event)
    {
        _id        = @event.Id;
        _companyId = @event.CompanyId;
    }

      //Change state of the job open or close
    public void ChangeJobState(Guid JobId, Guid CompanyId, bool IsOpen)
    {
        RaiseEvent(new JobChangeStateEvent
        {
            JobId     = JobId,
            CompanyId = CompanyId,
            IsOpen    = IsOpen
        });
    }


    public void Apply(JobChangeStateEvent @event)
    {
        _id        = @event.Id;
        _companyId = @event.CompanyId;
        _isOpen    = @event.IsOpen;
    }

      //delete of the job open or close

    public void DeleteJob(Guid JobId, bool IsDeleted)
    {
        RaiseEvent(new JobDeletedEvent
        {
            JobId     = JobId,
            IsDeleted = IsDeleted
        });
    }


    public void Apply(JobDeletedEvent @event)
    {
        _id        = @event.JobId;
        _isDeleted = @event.IsDeleted;
    }

      //Remove job 

    public void RemoveJob(Guid JobId)
    {
        RaiseEvent(
            new JobRemovedEvent
            {
                JobId = JobId
            }
        );

    }

    public void Apply(JobRemovedEvent @event)
    {
        _id = @event.JobId;
    }

}