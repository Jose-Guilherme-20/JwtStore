﻿namespace JwtStore.Core;

public static class Configuration
{
    public static SecretsConfiguration Secrets { get; set; } = new();
    public static DatabaseConfiguration Database { get; set; } = new();
    public static SendGridConfiguration SendGrid { get; set; } = new();
    public static EmailConfiguration Email { get; set; } = new();
    
    
    public class SecretsConfiguration
    {
        public string ApiKey { get; set; } = string.Empty;
        public string JwtPrivateKey { get; set; } = string.Empty;
        public string PasswordSaltKey { get; set; } = String.Empty;

    }
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
    
    public class  SendGridConfiguration
    {
        public string ApiKey { get; set; }
    }
    public class EmailConfiguration
    {
        public string DefaultFromEmail { get; set; } = "teste@teste.com";
        public string DefaultFromName { get; set; } = "teste@teste.com";
    }
}