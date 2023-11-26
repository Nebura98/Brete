using Brete.Common.Events.Job;
using CQRS.Core.Domain;


namespace Brete.Cmd.Domain.Aggregates.JobAggregate;

public sealed class JobAggregate : AggregateRoot
{
    private Guid _companyId;
    private bool _isOpen = false;
    private bool _isDeleted = false;
    private bool _active;

    public Guid CompanyId { get => _companyId; set => _companyId = value; }
    public bool IsDeleted { get => _isDeleted; set => _isDeleted = value; }
    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    public bool Active { get => _active; set => _active = value; }

    public JobAggregate()
    {
    }

    //Add new job event
    public JobAggregate(Guid jobId, Guid companyId, string title, string description, IReadOnlyList<string> skills, decimal salary, string seniority, string modality)
    {
        var jobTitle = new JobTitle(title);
        var jobDescription = new JobDescription(description);
        var jobSalary = new JobMoney(salary, "", "");
        var jobSeniority = new JobSeniority(seniority);
        var jobModality = new JobModality(modality);

        RaiseEvent(new JobCreatedEvent
        {
            Id = jobId,
            CompanyId = companyId,
            Title = jobTitle.Value,
            Description = jobDescription.Value,
            Skills = skills,
            Salary = jobSalary.Salary,
            Seniority = jobSeniority.Value,
            Modality = jobModality.Value,
        });
    }

    public void Apply(JobCreatedEvent @event)
    {
        _id = @event.Id;
        _companyId = @event.CompanyId;
    }


    //Edit job
    public void EditJob(Guid jobId, string title, string description, List<string> skills, decimal salary, string seniority, string modality)
    {

        var jobTitle = new JobTitle(title);
        var jobDescription = new JobDescription(description);
        var jobMoney = new JobMoney(salary, "", "");
        var jobSeniority = new JobSeniority(seniority);
        var jobModality = new JobModality(modality);

        RaiseEvent(new JobUpdatedEvent
        {
            JobId = jobId,
            Title = jobTitle.Value,
            Description = jobDescription.Value,
            Skills = skills,
            Salary = jobMoney.Salary,
            Seniority = jobSeniority.Value,
            Modality = jobModality.Value,
        });
    }

    public void Apply(JobUpdatedEvent @event)
    {
        _id = @event.Id;
    }

    //Change state of the job open or close
    public void ChangeJobState(Guid JobId, Guid CompanyId, bool IsOpen)
    {
        RaiseEvent(new JobChangeStateEvent
        {
            JobId = JobId,
            CompanyId = CompanyId,
            IsOpen = IsOpen
        });
    }


    public void Apply(JobChangeStateEvent @event)
    {
        _id = @event.Id;
        _companyId = @event.CompanyId;
        _isOpen = @event.IsOpen;
    }

    //delete of the job open or close
    public void DeleteJob(Guid JobId, bool IsDeleted)
    {
        RaiseEvent(new JobDeletedEvent
        {
            JobId = JobId,
            IsDeleted = IsDeleted
        });
    }


    public void Apply(JobDeletedEvent @event)
    {
        _id = @event.JobId;
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