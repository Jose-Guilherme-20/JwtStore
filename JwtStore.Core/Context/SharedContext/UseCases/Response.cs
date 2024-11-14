using Flunt.Notifications;

namespace JwtStore.Core.Context.SharedContext.UseCases;

public class Response
{
    public string Message { get; set; } = String.Empty;
    public int Status { get; set; } = 400;
    public bool IsSucess => Status is >= 200 and <= 299;
    public IEnumerable<Notification>? Notifications { get; set; }
}