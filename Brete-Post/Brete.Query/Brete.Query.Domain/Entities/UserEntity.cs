using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Brete.Query.Domain.Entities;

[Table("User", Schema = "dbo")]
public class UserEntity : BaseEntity
{
    [Required, StringLength(128)]
    public string FullName { get; set; }

    [Required, StringLength(50)]
    public string UserName { get; set; }

    [Required, StringLength(50)]
    public string Email { get; set; }
    [Required, JsonIgnore]
    public string Password { get; set; }

    [StringLength(20)]
    public string PhoneNumber { get; set; }
}
