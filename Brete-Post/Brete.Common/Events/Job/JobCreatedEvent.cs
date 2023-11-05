using CQRS.Core.Events;
using System.ComponentModel.DataAnnotations;

namespace Brete.Common.Events.Job;

public sealed record JobCreatedEvent : BaseEvent
{
    public JobCreatedEvent() : base(nameof(JobCreatedEvent)) { }

    public required Guid CompanyId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public ICollection<Guid> Skills { get; set; }
    public required decimal Salary { get; set; }
    public required byte Seniority { get; set; }
    public required byte Modality { get; set; }
}
