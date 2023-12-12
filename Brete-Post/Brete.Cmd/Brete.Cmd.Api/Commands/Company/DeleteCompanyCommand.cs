using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands.Company;

public record DeleteCompanyCommand : BaseCommand
{
    public bool IsDeleted { get; set; }
}
