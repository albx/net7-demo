using Microsoft.AspNetCore.SignalR;

namespace Net7Demo.Blazor.Hosted.Server;

public class DemoHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
