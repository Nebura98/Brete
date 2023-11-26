namespace CQRS.Core.Domain.ValueObject;

internal interface INormalize
{
    abstract bool CheckDomainRules<T>(T value);
}
