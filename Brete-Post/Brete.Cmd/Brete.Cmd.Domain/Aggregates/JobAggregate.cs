using Brete.Common.Events;
using CQRS.Core.Domain;

namespace Brete.Cmd.Domain.Aggregates;

enum Seniority
{
    Entry,
    Junior,
    Medium,
    Senior,
    Lead
};

enum Modality
{
    Remote,
    Office,
    Hybrid
};

public sealed class JobAggregate : AggregateRoot
{
    private string _title;
    private Guid _companyId ;
    private string _description ;
    private decimal _salary ;
    private byte _seniority;
    private byte _modality ;
    private bool _isOpen ;
    private bool _isDeleted ;
    private bool _active;

    public string Title { get => _title; set => _title = value; }
    public Guid CompanyId { get => _companyId; set => _companyId = value; }
    public string Description { get => _description; set => _description = value; }
    public decimal Salary { get => _salary; set => _salary = value; }
    public byte Seniority { get => _seniority; set => _seniority = value; }
    public byte Modality { get => _modality; set => _modality = value; }
    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    public bool IsDeleted { get => _isDeleted; set => _isDeleted = value; }
    public bool Active { get => _active; set => _active = value; }

    public JobAggregate()
    {
    }

    public JobAggregate(Guid id, Guid companyId, string Title, String description, Decimal salary, byte seniority, byte modality, bool isOpen, bool isDeleted)
    {
        RaiseEvent(new JobCreatedEvent
        {
            Id = id,
            Title = Title,
            CompanyId = companyId,
            Description = description,
            Salary = salary,
            Seniority = seniority,
            Modality = modality,
            IsOpen = isOpen,
            IsDeleted = isDeleted
        });
    }

    public void Apply (JobCreatedEvent @event)
    {
        _id = @event.Id;
        _companyId = @event.CompanyId;
        _title = @event.Title;
        _description = @event.Description;
        _salary = @event.Salary;
        _seniority = @event.Seniority;
        _modality = @event.Modality;
        _isOpen = @event.IsOpen;
        _isDeleted = @event.IsDeleted;
        _active = true;
    }
}