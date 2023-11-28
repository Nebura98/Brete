namespace CQRS.Core.Domain.ValueObject;

public abstract class StringValueObject : ValueObject, INormalize
{
    public string Value { get; private set; }

    protected StringValueObject(string value)
    {
        Value = CheckDomainRules(value) ? value.Trim().ToUpperInvariant() : string.Empty;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    public abstract bool CheckDomainRules<T>(T value);
}
