namespace CQRS.Core.Domain.ValueObject;

public abstract class GuidValueObject : ValueObject
{
    public Guid Value { get; init; }

    protected GuidValueObject(Guid value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    public abstract bool Normalize<T>(T value);
}
