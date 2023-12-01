using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brete.Query.Domain.Entities;

[Table("Company", Schema = "dbo")]
[Index(nameof(Name), IsUnique = true)]
[Index(nameof(LegalName), IsUnique = true)]
public class CompanyEntity
{
    [Key]
    public string Id { get; set; }
    [Required, StringLength(128)]
    public string Name { get; set; }
    [Required, StringLength(128)]
    public string LegalName { get; set; }
    [Required, StringLength(128)]
    public string Address { get; set; }
    [StringLength(20)]
    public string Phone { get; set; }
    [Required, StringLength(128)]
    public string Email { get; set; }
    [StringLength(128)]
    public string Website { get; set; }
    [Required, StringLength(128)]
    public string Industry { get; set; }
    public string Size { get; set; }
    public DateTime FoundingDate { get; set; }
    public string Status { get; set; }
    public bool IsActive { get; set; }
}
