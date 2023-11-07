using System.Text;

namespace CQRS.Core.Domain.ValueObject;

public sealed record Result<T>
{
    public bool IsSuccess { get; private init; }
    public T? Value { get; private init; }
    public string? ErrorMessage { get; private init; }
    private Result() { }
    public static Result<T> Success(T value)             => new() { IsSuccess = true, Value = value };
    public static Result<T> Failure(string errorMessage) => new()
    {
        IsSuccess    = false,
        ErrorMessage = errorMessage
    };
    public static string GetErrorMessages(IReadOnlyCollection<Result<T>> results)
    {
        StringBuilder ErrorMessages = new();
        foreach (var result in results)
        {
            if (result.IsSuccess is false)
            {
                string ErrorTitle   = result.ErrorMessage.Split(',')[0];
                string ErrorMessage = result.ErrorMessage.Split(ErrorTitle)[1];
                ErrorMessages.AppendLine(
                    $"{ErrorTitle}:[{ErrorMessage}]"
                );
            }
        }

        return ErrorMessages.ToString();
    }
}
