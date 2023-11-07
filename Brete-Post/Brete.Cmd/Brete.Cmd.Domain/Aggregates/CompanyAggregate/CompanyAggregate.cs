using CQRS.Core.Domain;

namespace Brete.Cmd.Domain.Aggregates;

public sealed class CompanyAggregate : AggregateRoot
{
    private bool _active;

    public bool Active { get => _active; set => _active = value; }
    public CompanyAggregate()
    {
    }
}
