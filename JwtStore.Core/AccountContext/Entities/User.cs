﻿using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.SharedContext.Entities;
using Email = JwtStore.Core.Context.AccountContext.ValueObjects.Email;

namespace JwtStore.Core.AccountContext.Entities;

public class User : Entity
{
    public User()
    {
        
    }
    public User(string email, string? password = null)
    {
        Email = email;
        Password = new Password(password);
    }

    public string Name { get; private set; } = string.Empty;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
    public string Image { get; set; } = null!;

    public void UpdatePassword(string plainTextPassword, string code)
    {
        if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
        {
            throw new Exception("Código de restauração inválido");
        }

        var password = new Password(plainTextPassword);
        Password = password;
    }

    public void UpdateEmail(Email email)
    {
        Email = email;
    }

    public void ChangePassword(string plainTextPassword)
    {
        var password = new Password(plainTextPassword);
        Password = password;
    }
}