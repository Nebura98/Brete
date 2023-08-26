namespace Brete.Query.Domain.Repositories;

public interface ICompanyRepository
{
    Task CreateAsync();
    Task UpdateAsync();
    Task DeleteAsync();
    Task GetByIdAsync(Guid companyId);
    Task <List<Guid>> ListAllAsync();
    Task<List<Guid>> SearchByCriteriaAsync();
}
