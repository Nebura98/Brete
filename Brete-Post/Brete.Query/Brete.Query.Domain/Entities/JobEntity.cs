using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Brete.Query.Domain.Entities;

[Table("Job", Schema = "dbo")]
public class JobEntity : BaseEntity
{
    [Required]
    public Guid CompanyId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Slug { get; set; }
    [Required]
    public string? Description { get; set; }
    public virtual ICollection<Guid>? Skills { get; }
    [Required]
    public decimal Salary { get; set; }
    [Required]
    public string Seniority { get; set; }
    [Required]
    public string Modality { get; set; }
    [Required, JsonIgnore]
    public bool IsEdited { get; set; }
}
