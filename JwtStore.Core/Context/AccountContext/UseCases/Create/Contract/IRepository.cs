﻿using JwtStore.Core.Context.AccountContext.Entities;

namespace JwtStore.Core.Context.AccountContext.UseCases.Create.Contract;

public interface IRepository
{
    Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
    Task SaveAsync(User user, CancellationToken cancellationToken);
}