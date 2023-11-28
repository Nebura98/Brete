using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brete.Query.Domain.Entities;

[Table("Company", Schema = "dbo")]
public class CompanyEntity
{
    [Key]
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string WebSite { get; set; }
    //public virtual ICollection<Guid> CompanyAssociate { get; set; }
}
