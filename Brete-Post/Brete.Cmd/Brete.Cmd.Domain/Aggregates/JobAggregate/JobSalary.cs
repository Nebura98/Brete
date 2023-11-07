using CQRS.Core.Domain.ValueObject;

namespace Brete.Cmd.Domain.Aggregates.JobAggregate;

public sealed class JobSalary
{
    private static readonly IReadOnlyCollection<string> SUPPORTEDCURRENCIES = new[] { "USD", "EUR", "CRC" };
    private static readonly IReadOnlyCollection<string> PAYFREQUENTLY       = new[] { "Hour", "Daily", "Weekly", "Biweekly", "Monthly", "Yearly" };
    
    private decimal Amount { get; init; }
    private string Currency { get; init; }
    private string Frequently { get; init; }
    private JobSalary(decimal amount, string currency, string frequently)
    {
        Amount     = amount;
        Currency   = currency;
        Frequently = frequently;
    }


    public string ToString => $"{Currency} - {Amount} - {Frequently}";

    public static Result<JobSalary> Create(decimal amount, string currency, string frequently)
    {
        List<string> ErrorMessages = new();

        if (string.IsNullOrWhiteSpace(currency))
        {
            ErrorMessages.Add("Currency can not be empty");
        }

        if (!SUPPORTEDCURRENCIES.Contains(currency))
        {
            ErrorMessages.Add($"Just {SUPPORTEDCURRENCIES.ToString} currencies are supported by now");
        }

        if (amount.Equals(null))
        {
            return Result<JobSalary>.Failure("Salary can not be empty");
        }

        if (!decimal.IsPositive(amount))
        {
            ErrorMessages.Add("Salary should be positive");
        }

        if (string.IsNullOrWhiteSpace(frequently))
        {
            ErrorMessages.Add("Frequently can not be empty");
        }

        if (!PAYFREQUENTLY.Contains(currency))
        {
            ErrorMessages.Add($"Just {PAYFREQUENTLY.ToString} frequently are supported by now");
        }

        return ErrorMessages.Count < 1
               ? Result<JobSalary>.Failure(string.Join(",", ErrorMessages))
               :   Result<JobSalary>.Success(new(amount, currency, frequently));
    }
}
