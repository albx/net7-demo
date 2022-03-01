// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("Hello, World!");

HubConnection connection = new HubConnectionBuilder().WithUrl("https://localhost:7068/demo").Build();
var stronglyTypedConnection = connection.ServerProxy<IServerHub>();
var registrations = connection.ClientRegistration<IClient>(new Client());

await stronglyTypedConnection.SendMessage("Hello world");
var echo = await stronglyTypedConnection.Echo(10);

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


[AttributeUsage(AttributeTargets.Method)]
internal class HubServerProxyAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Method)]
internal class HubClientProxyAttribute : Attribute
{
}

internal static partial class MyCustomExtensions
{
    [HubClientProxy]
    public static partial IDisposable ClientRegistration<T>(this HubConnection connection, T provider);

    [HubServerProxy]
    public static partial T ServerProxy<T>(this HubConnection connection);
}
