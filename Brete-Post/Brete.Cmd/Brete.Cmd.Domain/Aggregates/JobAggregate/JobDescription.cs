using CQRS.Core.Domain.ValueObject;

namespace Brete.Cmd.Domain.Aggregates.JobAggregate;
public sealed class JobDescription : StringValueObject
{
    public JobDescription(string value) : base(value)
    {
    }
}
