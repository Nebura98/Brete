namespace CQRS.Core.Exceptions;

public sealed class AggregateNotFoundException : Exception
{
    public AggregateNotFoundException(string message) : base(message) { }
}
