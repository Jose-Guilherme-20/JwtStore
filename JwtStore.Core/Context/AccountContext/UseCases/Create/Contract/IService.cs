using JwtStore.Core.Context.AccountContext.Entities;

namespace JwtStore.Core.Context.AccountContext.UseCases.Create.Contract;

public interface IService
{
    Task SendVerificationEmailAsync(User user, CancellationToken cancellationToken);
}