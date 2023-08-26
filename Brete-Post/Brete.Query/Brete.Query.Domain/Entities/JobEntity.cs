using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brete.Query.Domain.Entities;

[Table("Job", Schema ="dbo")]
public sealed class JobEntity
{
    [Key]
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public string Title { get; set; }  
    public string Description { get; set; }
    public decimal Salary { get; set; }
    public byte Seniority { get; set; }
    public byte Modality { get; set; }
    public bool IsOpen { get; set; }
    public bool IsDeleted { get; set; }

}
