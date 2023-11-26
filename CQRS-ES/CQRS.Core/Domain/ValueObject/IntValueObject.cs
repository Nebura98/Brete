namespace CQRS.Core.Domain.ValueObject;

public abstract class IntValueObject : ValueObject, INormalize
{
    public int Value { get; init; }

    protected IntValueObject(int value)
    {
        Value = value;
    }

    public abstract void NormalizeValue();

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public bool CheckDomainRules<T>(T value)
    {
        throw new NotImplementedException();
    }
}
