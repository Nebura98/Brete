using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brete.Query.Domain.Entities;

[Table("Job", Schema = "dbo")]
public class JobEntity
{
    [Key]
    public Guid JobId { get; set; }
    [Required]
    public Guid CompanyId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public virtual ICollection<SkillEntity>? Skills { get; set; }
    [Required]
    public decimal Salary { get; set; }
    [Required]
    public string Seniority { get; set; }
    [Required]
    public string Modality { get; set; }
    [Required]
    public bool IsOpen { get; set; }
    [Required]
    public bool IsDeleted { get; set; }
}
