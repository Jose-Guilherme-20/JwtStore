using JwtStore.Core.Context.AccountContext.Entities;
using JwtStore.Core.Context.AccountContext.UseCases.Authenticate.Contract;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.AccountContext.UseCases.Authenticate;

public class Repository : IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmailAsync(string requestEmail, CancellationToken cancellationToken)
    {
        return await _context
            .Users.AsNoTracking()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Email.Address.Equals(requestEmail));
    }
}