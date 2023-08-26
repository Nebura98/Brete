using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brete.Query.Domain.Entities;

[Table("Company", Schema = "dbo")]
public class CompanyEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}
