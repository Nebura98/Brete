using CQRS.Core.Events;

namespace Brete.Common.Events.Company;

public sealed record CompanyUpdatedEvent : BaseEvent
{
    public CompanyUpdatedEvent() : base(nameof(CompanyUpdatedEvent))
    {
    }
    public string Name { get; set; }
    public string LegalName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string Industry { get; set; }
    public string Size { get; set; }
    public DateTime FoundingDate { get; set; }
}
