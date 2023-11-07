using CQRS.Core.Domain.ValueObject;

namespace Brete.Cmd.Domain.Aggregates.JobAggregate;

internal enum Modality
{
    Remote,
    Office,
    Hybrid
};

public sealed class JobModality : StringValueObject
{
    private JobModality(string value) : base(value)
    {
    }

    public static Result<JobModality> Create(string modality)
    {
        List<string> ErrorMessages = new() { "Modality" };

        if (string.IsNullOrWhiteSpace(modality))
        {
            ErrorMessages.Add("Modality can not be empty");
        }

        if (!Enum.IsDefined(typeof(Modality), modality))
        {
            ErrorMessages.Add($"Job modality just allow the following values '[Remote, Office,  Hybrid]'");
        }

        return ErrorMessages.Count < 1
                ? Result<JobModality>.Failure(string.Join(",", ErrorMessages))
                : Result<JobModality>.Success(new(modality));
    }
}
