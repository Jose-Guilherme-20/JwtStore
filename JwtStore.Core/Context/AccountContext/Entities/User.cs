﻿using JwtStore.Core.Context.AccountContext.ValueObjects;
using JwtStore.Core.Context.SharedContext.Entities;


namespace JwtStore.Core.Context.AccountContext.Entities;

public class User : Entity
{
    public User()
    {
        
    }
    public User(string name, string email, Password password )
    {
        Name = name;
        Email = email;
        Password = password;
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
    public List<Role> Roles { get; set; } = new();

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