namespace CQRS.Core.Domain.ValueObject;

public abstract class IntValueObject : ValueObject
{
    public int Value { get; init; }

    protected IntValueObject(int value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
