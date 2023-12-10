using Brete.Query.Domain.Entities;
using CQRS.Core.Infrastructure;

namespace Brete.Query.Domain.Repositories;

public interface ICompanyRepository : IBaseRepository<CompanyEntity>
{
    Task<List<CompanyEntity>> SearchByCriteriaAsync();
}
