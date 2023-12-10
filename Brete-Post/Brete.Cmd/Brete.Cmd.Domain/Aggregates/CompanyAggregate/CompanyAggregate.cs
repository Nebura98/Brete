using Brete.Common.Events.Company;
using CQRS.Core.Domain;

namespace Brete.Cmd.Domain.Aggregates.CompanyAggregate;

public sealed class CompanyAggregate : AggregateRoot
{
    private bool _active;
    public bool Active { get => _active; set => _active = value; }

    public CompanyAggregate()
    {
    }

    public CompanyAggregate(Guid companyId, string name, string legalName, string address, string phone, string email, string website, string industry, string size, DateTime foundingDate)
    {
        RaiseEvent(new CompanyCreatedEvent
        {
            Id = companyId,
            Name = name,
            LegalName = legalName,
            Address = address,
            Phone = phone,
            Email = email,
            Website = website,
            Industry = industry,
            Size = size,
            FoundingDate = foundingDate,
        });
    }

    public void Apply(CompanyCreatedEvent @event)
    {
        _id = @event.Id;
        _active = true;
    }

    public void UpdateCompany(string name, string legalName, string address, string phone, string email, string website, string industry, string size, DateOnly foundingDate, string status, bool isActive)
    {
        RaiseEvent(
            new CompanyUpdatedEvent
            {
                Name = name,
                LegalName = legalName,
                Address = address,
                Phone = phone,
                Email = email,
                Website = website,
                Industry = industry,
                Size = size,
                FoundingDate = foundingDate,
                Status = status,
                IsActive = isActive
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
            new CompanyDeletedEvent
            {
                Id = companyId
            });
    }

    public void Apply(CompanyDeletedEvent @event)
    {
        _id = @event.Id;
        _active = true;
    }
}
