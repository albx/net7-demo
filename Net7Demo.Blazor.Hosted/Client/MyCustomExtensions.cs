using Microsoft.AspNetCore.SignalR.Client;

namespace Net7Demo.Blazor.Hosted.Client;

internal static partial class MyCustomExtensions
{
    [HubClientProxy]
    public static partial IDisposable ClientRegistration<T>(this HubConnection connection, T provider);

    [HubServerProxy]
    public static partial T ServerProxy<T>(this HubConnection connection);
}

public interface IServerHub
{
    Task SendMessage(string message);
    Task<int> Echo(int i);
}

public interface IClient
{
    Task ReceiveMessage(string message);
}

public class Client : IClient
{
    // Equivalent to HubConnection.On("ReceiveMessage", (message) => {});
    public Task ReceiveMessage(string message)
    {
        return Task.CompletedTask;
    }
}
