using CQRS.Core.Events;

namespace Brete.Common.Events.Company;

public sealed record CompanyCreatedEvent : BaseEvent
{
    public CompanyCreatedEvent() : base(nameof(CompanyCreatedEvent))
    {
    }
    public required string Name { get; set; }
    public required string LegalName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public required string Email { get; set; }
    public string Website { get; set; }
    public required string Industry { get; set; }
    public string Size { get; set; }
    public DateOnly FoundingDate { get; set; }
    public string Status { get; set; }
    public bool IsActive { get; set; }
}
