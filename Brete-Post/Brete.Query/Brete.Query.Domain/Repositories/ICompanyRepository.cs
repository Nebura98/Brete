using Brete.Query.Domain.Entities;

namespace Brete.Query.Domain.Repositories;

public interface ICompanyRepository
{
    Task CreateAsync(CompanyEntity company);
    Task UpdateAsync(CompanyEntity company);
    Task DisableAsync(Guid companyId);
    Task DeleteAsync(Guid companyId);
    Task GetByIdAsync(Guid companyId);
    Task<List<CompanyEntity>> ListAllAsync();
    Task<List<CompanyEntity>> SearchByCriteriaAsync();
}
