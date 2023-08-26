using Brete.Query.Domain.Repositories;

namespace Brete.Query.Infrastructure.Handlers;

public class EventHandler : IEventHandler
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IJobRepository _jobRepository;

    public EventHandler(IJobRepository jobRepository, ICompanyRepository companyRepository)
    {
        _jobRepository = jobRepository;
        _companyRepository = companyRepository;
    }
}
