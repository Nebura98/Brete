using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brete.Query.Domain.Entities;

[Table("Skill", Schema = "dbo")]
[Index(nameof(Name), IsUnique = true)]
public class SkillEntity
{
    [Key]
    public Guid Id { get; set; }
    [Required, StringLength(50)]
    public string Name { get; set; }
    [StringLength(200)]
    public string Description { get; set; }
    [Required, MaxLength(50)]
    public string Section { get; set; }
    [Required]
    public bool IsDisable { get; set; }
}
