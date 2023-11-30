using Brete.Common.Events.Company;
using CQRS.Core.Domain;

namespace Brete.Cmd.Domain.Aggregates;

public sealed class CompanyAggregate : AggregateRoot
{
    private bool _active;
    public bool Active { get => _active; set => _active = value; }
    public CompanyAggregate(Guid companyId)
    {
        RaiseEvent(new CompanyCreatedEvent
        {
            Id = companyId,
        });
    }

    public void Apply(CompanyCreatedEvent @event)
    {
        _id = @event.Id;
        _active = true;
    }

    public void UpdateCompany(Guid companyId)
    {
        RaiseEvent(
            new CompanyUpdatedEvent
            {
                Id = companyId
            });
    }

    public void Apply(CompanyUpdatedEvent @event)
    {
        _id = @event.Id;
        _active = true;
    }

    public void DisableCompany(Guid companyId)
    {
        RaiseEvent(
            new CompanyDisableEvent
            {
                Id = companyId
            });
    }

    public void Apply(CompanyDisableEvent @event)
    {
        _id = @event.Id;
        _active = true;
    }

    public void RemoveCompany(Guid companyId)
    {
        RaiseEvent(
            new CompanyRemovedEvent
            {
                Id = companyId
            });
    }

    public void Apply(CompanyRemovedEvent @event)
    {
        _id = @event.Id;
        _active = true;
    }
}
