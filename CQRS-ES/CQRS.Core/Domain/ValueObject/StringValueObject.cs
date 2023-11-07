namespace CQRS.Core.Domain.ValueObject;

public abstract class StringValueObject: ValueObject
{
    public string Value { get; init; }

    protected StringValueObject(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
