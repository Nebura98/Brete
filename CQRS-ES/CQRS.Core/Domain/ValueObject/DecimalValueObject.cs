namespace CQRS.Core.Domain.ValueObject;

public abstract class DecimalValueObject: ValueObject
{
    public decimal Value { get; init; }

    protected DecimalValueObject(decimal value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
