using CQRS.Core.Domain.ValueObject;

namespace Brete.Cmd.Domain.Aggregates.JobAggregate;

internal enum Seniority
{
    Entry,
    Junior,
    Medium,
    Senior,
    Lead,
};


public class JobSeniority : StringValueObject
{
    private JobSeniority(string value) : base(value)
    {
    }

    public static Result<JobSeniority> Create(string seniority)
    {
        List<string> ErrorMessages = new();

        if (string.IsNullOrWhiteSpace(seniority))
        {
            ErrorMessages.Add("Seniority can not be empty");
        }

        if (!Enum.IsDefined(typeof(Seniority), seniority))
        {
            ErrorMessages.Add($"Job just allow the following values '[Entry, Junior, Medium, Senior,Lead]'");
        }

        return ErrorMessages.Count < 1
                     ? Result<JobSeniority>.Failure(string.Join(",", ErrorMessages))
                     : Result<JobSeniority>.Success(new(seniority));
    }
}
