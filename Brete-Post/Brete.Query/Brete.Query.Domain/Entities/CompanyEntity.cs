using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brete.Query.Domain.Entities;

[Table("Company", Schema = "dbo")]
public class CompanyEntity
{
    [Key]
    public Guid CompanyId { get; set; }
    [Required, StringLength(128)]
    public string Name { get; set; }
    [StringLength(128)]
    public string Location { get; set; }
    public string Country { get; set; }
}
