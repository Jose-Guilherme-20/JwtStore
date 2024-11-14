using JwtStore.Core.Context.AccountContext.Entities;
using JwtStore.Core.Context.AccountContext.UseCases.Create.Contract;
using JwtStore.Core.Context.AccountContext.ValueObjects;
using MediatR;

namespace JwtStore.Core.Context.AccountContext.UseCases.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;
    private readonly IService _service;

    public Handler(IRepository repository, IService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Valida a requisição

        try
        {
            var res = Specification.Ensure(request);
            if (!res.IsValid)
            {
                return new Response("Requisição inválida", 400, res.Notifications);
            }
            
        }
        catch (Exception e)
        {
            return new Response("Não foi possível validar sua requisição", 500);
        }

        #endregion

        #region 02. Gera os Objetos

        Email email;
        Password password;
        User user;

        try
        {
            email = new Email(request.Email);
            password = new Password(request.Password);
            user = new User(request.Name, email, password);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }

        #endregion

        #region 03. Verifica se o usuário existe no banco

        try
        {
            var exists = await _repository.AnyAsync(request.Email, cancellationToken);
            if (exists)
            {
                return new Response("Este E-mail já está em uso", 400);
            }
        }
        catch (Exception ex)
        {
            return new Response("Falha ao verificar se o usuário existe no banco", 500);
        }

        #endregion

        #region 04. Persiste os dados

        try
        {
            await _repository.SaveAsync(user, cancellationToken);
        }
        catch (Exception e)
        {
            return new Response("Falha ao persistir dados", 500);
        }

        #endregion

        #region 05. Notificar o usuario

        try
        {
            await _service.SendVerificationEmailAsync(user, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        #endregion

        return new Response("Conta criada", new ResponseData(user.Id, user.Name, user.Email));
    }
    
}