using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands.Company;

public record CreateCompanyCommand : BaseCommand
{
    public required string Name { get; set; }
    public string LegalName { get; set; }
    public required string Address { get; set; }
    public string Phone { get; set; }
    public required string Email { get; set; }
    public string Website { get; set; }
    public required string Industry { get; set; }
    public string Size { get; set; }
    public DateTime FoundingDate { get; set; }
}
