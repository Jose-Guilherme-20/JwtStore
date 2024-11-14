namespace JwtStore.API.Extensions;

public static class AccountContextExtension
{
    public static void AddAccountContext(this WebApplicationBuilder builder)
    {
        #region Create

        builder.Services.AddTransient<
            JwtStore.Core.Context.AccountContext.UseCases.Create.Contract.IRepository,
            JwtStore.Infra.AccountContext.UseCases.Create.Repository>();
        
        builder.Services.AddTransient<
            JwtStore.Core.Context.AccountContext.UseCases.Create.Contract.IService,
            JwtStore.Infra.AccountContext.UseCases.Create.Service>();

        #endregion

        #region Authenticate

        builder.Services.AddTransient<
            JwtStore.Core.Context.AccountContext.UseCases.Authenticate.Contract.IRepository,
            JwtStore.Infra.AccountContext.UseCases.Authenticate.Repository>();

        #endregion
    }
    
    public static void MapAccountEndpoints(this WebApplicationBuilder builder)
    {
        
    }
}