using Brete.Query.Domain.Repositories;

namespace Brete.Query.Infrastructure.Handlers;

public class EventHandler : IEventHandler
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IJobRepository _jobRepository;
    private readonly ISkillRepository _skillRepository;

    public EventHandler(IJobRepository jobRepository, ICompanyRepository companyRepository, ISkillRepository skillRepository)
    {
        _jobRepository = jobRepository;
        _companyRepository = companyRepository;
        _skillRepository = skillRepository;
    }
}
