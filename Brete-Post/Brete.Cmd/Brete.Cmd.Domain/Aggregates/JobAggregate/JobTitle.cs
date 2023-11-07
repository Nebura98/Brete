using CQRS.Core.Domain.ValueObject;

namespace Brete.Cmd.Domain.Aggregates.JobAggregate;
public sealed class JobTitle : StringValueObject
{
    public JobTitle(string value) : base(value)
    {
    }
}
