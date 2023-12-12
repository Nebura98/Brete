using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Brete.Query.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    [JsonIgnore]
    public bool IsActive { get; set; }
    [JsonIgnore]
    public bool IsDeleted { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; }
    [JsonIgnore]
    public DateTime UpdatedAt { get; set; }
}
