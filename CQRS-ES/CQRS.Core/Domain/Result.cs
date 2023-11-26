
namespace CQRS.Core.Domain.ValueObject;

public sealed record Result
{
    public bool IsSuccess { get; private init; }
    public List<string> ErrorMessages { get; private init; } = Enumerable.Empty<string>().ToList();
    private Result() { }
    public static Result Success() => new() { IsSuccess = true };
    public static Result Failure(List<string> errorMessages) => new()
    {
        IsSuccess = false,
        ErrorMessages = errorMessages
    };
}
