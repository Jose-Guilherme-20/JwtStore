using JwtStore.Core.Context.AccountContext.Entities;

namespace JwtStore.Core.Context.AccountContext.UseCases.Authenticate.Contract;

public interface IRepository
{
    Task<User?> GetUserByEmailAsync(string requestEmail, CancellationToken cancellationToken);

}