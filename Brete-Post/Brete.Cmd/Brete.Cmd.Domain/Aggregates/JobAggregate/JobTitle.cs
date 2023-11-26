using CQRS.Core.Domain.ValueObject;
using System.Text.RegularExpressions;

namespace Brete.Cmd.Domain.Aggregates.JobAggregate;


public sealed class JobTitle : StringValueObject
{
    public JobTitle(string value) : base(value)
    {
    }


    public override bool CheckDomainRules<T>(T value)
    {
        string PATTERN = @"^[A-Za-z/.,]+$";

        if (string.IsNullOrWhiteSpace(Value))
        {
            ErrorMessages.Add("Title can not be empty");
        }

        if (Value.Length < 128)
        {
            ErrorMessages.Add("Title should be between 1 and 128 of length");
        }

        if (!Regex.IsMatch(Value, PATTERN))
        {
            ErrorMessages.Add("Title just allow letter from A to Z and this '/.,' ");
        }

        return ErrorMessages.Count == 0;
    }
}
