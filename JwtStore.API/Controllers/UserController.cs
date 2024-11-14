using JwtStore.API.Extensions;
using JwtStore.Core.Context.AccountContext.UseCases.Create;
using JwtStore.Core.Context.AccountContext.UseCases.Create.Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JwtStore.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/v1/users")] 

public class UserController : ControllerBase
{
    
    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <remarks>
    /// Retorna usuário cadastrado
    /// </remarks>
    /// <response code="200">Retorna o usuário criado.</response>
    /// <response code="400">Erro de requisição.</response>
    /// <response code="401">Acesso negado.</response>
    /// <response code="500">Erro interno da API.</response>
    [ProducesResponseType(typeof(Response), 201)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 401)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpPost("create")]
    public async Task<ActionResult<Response>> CreateUserAsync(Core.Context.AccountContext.UseCases.Create.Request requestCreate, [FromServices] IRequestHandler<Request, Response> handler)
    {
        var result = await handler.Handle(requestCreate, new CancellationToken());
            return result.IsSucess
                ? Created(String.Empty, result)
                    : BadRequest(result.Status);
    }
    
    /// <summary>
    /// Cria um token para um usuário.
    /// </summary>
    /// <remarks>
    /// Retorna credencias para um usuário
    /// </remarks>
    /// <response code="200">Retorna credenciais de um usuário.</response>
    /// <response code="400">Erro de requisição.</response>
    /// <response code="401">Acesso negado.</response>
    /// <response code="500">Erro interno da API.</response>
    [ProducesResponseType(typeof(Response), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 401)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpPost("Authenticate")]
    public async Task<ActionResult<Core.Context.AccountContext.UseCases.Authenticate.Response>> AuthenticateUserAsync(Core.Context.AccountContext.UseCases.Authenticate.Request requestAuth, [FromServices] IRequestHandler<Core.Context.AccountContext.UseCases.Authenticate.Request, Core.Context.AccountContext.UseCases.Authenticate.Response> handler)
    {
        var result = await handler.Handle(requestAuth, new CancellationToken());

        if (! result.IsSucess)
        {
            return BadRequest(result);
        }

        if (result.Data is null)
        {
            return NotFound(result);
        }

        result.Data.Token = JwtExtension.Generate(result.Data);
        return Ok(result);
    }
}