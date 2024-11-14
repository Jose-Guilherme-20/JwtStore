using System.Text.RegularExpressions;
using JwtStore.Core.SharedContext.Extensions;
using JwtStore.Core.SharedContext.ValueObjects;

namespace JwtStore.Core.AccountContext.ValueObjects;

public partial class Email : ValueObject
{
    protected Email()
    {
        
    }
    public string Address { get; }
    public string Hash  => Address.ToBase64();
    public Verification Verification { get; private set; } = new();

    public void ResendVerification()
        => new Verification();

    public static implicit operator Email(string address)
        => new(address);
    public static implicit operator string(Email email)
        => email.ToString();

    public override string ToString()
        => Address;

    public Email(string address)
    {
        if (string.IsNullOrEmpty(address))
        {
            throw new Exception("E-mail inválido");
        }

        Address = address.Trim().ToLower();

        if (Address.Length < 5)
        {
            throw new Exception("E-mail inválido");
        }
    }
}