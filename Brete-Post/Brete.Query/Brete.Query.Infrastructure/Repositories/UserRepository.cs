using Brete.Query.Domain.Entities;
using Brete.Query.Domain.Repositories;
using Brete.Query.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Brete.Query.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContextFactory _context;

    public UserRepository(DatabaseContextFactory context)
    {
        _context = context;
    }

    public async Task CreateAsync(UserEntity value)
    {
        using DatabaseContext context = _context.CreateDbContext();
        context.User.Add(value);

        await context.SaveChangesAsync();
    }

    public Task DeleteAsync(UserEntity value)
    {
        throw new NotImplementedException();
    }

    public Task DisableAsync(UserEntity value)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserEntity>> ListAllAsync()
    {
        using DatabaseContext context = _context.CreateDbContext();
        return await context
                    .User
                    .AsNoTracking()
                    .ToListAsync();
    }

    public Task UpdateAsync(UserEntity value)
    {
        throw new NotImplementedException();
    }
}
