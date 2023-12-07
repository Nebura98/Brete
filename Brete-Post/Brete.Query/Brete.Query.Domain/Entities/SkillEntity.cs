using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brete.Query.Domain.Entities;

[Table("Skill", Schema = "dbo")]
[Index(nameof(Name), IsUnique = true)]
public class SkillEntity : BaseEntity
{
    [Required, StringLength(50)]
    public string Name { get; set; }

    [StringLength(200)]
    public string Description { get; set; }

    [Required, MaxLength(50)]
    public string Section { get; set; }
}
