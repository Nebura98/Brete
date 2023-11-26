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
    public JobSeniority(string value) : base(value)
    {
    }

    public override bool CheckDomainRules<T>(T value)
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            ErrorMessages.Add("Seniority can not be empty");
        }

        if (!Enum.IsDefined(typeof(Seniority), Value))
        {
            ErrorMessages.Add($"Job just allow the following values '[Entry, Junior, Medium, Senior, Lead]'");
        }

        return ErrorMessages.Count == 0;
    }
}
