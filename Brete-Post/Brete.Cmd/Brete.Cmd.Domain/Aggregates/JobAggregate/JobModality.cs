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
    public JobModality(string value) : base(value)
    {
    }

    public override bool CheckDomainRules<T>(T value)
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            ErrorMessages.Add("Modality can not be empty");
        }

        if (!Enum.IsDefined(typeof(Modality), Value))
        {
            ErrorMessages.Add($"Job modality just allow the following values '[Remote, Office,  Hybrid]'");
        }

        return ErrorMessages.Count == 0;
    }
}
