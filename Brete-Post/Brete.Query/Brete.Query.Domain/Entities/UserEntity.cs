using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brete.Query.Domain.Entities;

[Table("User", Schema = "dbo")]
public class UserEntity
{
    [Key]
    public Guid Id { get; set; }
    [Required, StringLength(128)]
    public string FullName { get; set; }
    [Required, StringLength(50)]
    public string UserName { get; set; }
    [Required, StringLength(50)]
    public string Email { get; set; }
    [Required, StringLength(50)]
    public string Password { get; set; }
    [StringLength(14)]
    public string PhoneNumber { get; set; }
}
