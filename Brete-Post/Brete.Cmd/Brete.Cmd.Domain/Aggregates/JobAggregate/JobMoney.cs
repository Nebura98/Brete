using CQRS.Core.Domain.ValueObject;

namespace Brete.Cmd.Domain.Aggregates.JobAggregate;

public sealed class JobMoney
{
    private static readonly IReadOnlyList<string> SUPPORTEDCURRENCIES = new[] { "USD", "EUR", "CRC" };
    private static readonly IReadOnlyList<string> PAYFREQUENTLY = new[] { "Hour", "Daily", "Weekly", "Biweekly", "Monthly", "Yearly" };

    private decimal Amount { get; init; }
    private string Currency { get; init; }
    private string Frequently { get; init; }
    public JobMoney(decimal amount, string currency, string frequently)
    {
        Amount = amount;
        Currency = currency;
        Frequently = frequently;
    }

    public string Salary => $"{Currency} - {Amount} - {Frequently}";

    public Result Check()
    {
        List<string> ErrorMessages = new();

        if (string.IsNullOrWhiteSpace(Currency))
        {
            ErrorMessages.Add("Currency can not be empty");
        }

        if (!SUPPORTEDCURRENCIES.Contains(Currency))
        {
            ErrorMessages.Add($"Just {SUPPORTEDCURRENCIES.ToString} currencies are supported by now");
        }

        if (Amount.Equals(null))
        {
            return Result.Failure(ErrorMessages);
        }

        if (!decimal.IsPositive(Amount))
        {
            ErrorMessages.Add("Salary should be positive");
        }

        if (string.IsNullOrWhiteSpace(Frequently))
        {
            ErrorMessages.Add("Frequently can not be empty");
        }

        if (!PAYFREQUENTLY.Contains(Currency))
        {
            ErrorMessages.Add($"Just {PAYFREQUENTLY.ToString} frequently are supported by now");
        }

        return ErrorMessages.Count < 1
               ? Result.Failure(ErrorMessages)
               : Result.Success();
    }
}
