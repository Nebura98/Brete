using System.ComponentModel.DataAnnotations;

namespace Brete.Query.Domain.Entities;
public sealed class SkillEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Byte Type { get; set; }
}
