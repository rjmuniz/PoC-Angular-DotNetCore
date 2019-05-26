using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace backend
{
    public class MyBackgroundWorker : IHostedService
    {
        IHubContext<HubMessages> _hub;
        public MyBackgroundWorker(IHubContext<HubMessages> hub)
        {
            _hub = hub;
        }
        public Task DoAsync(int value)
        {
            for (int i = value; i == 0; i--)
                _hub.Clients.All.SendAsync("ReceiveMessage", i.ToString());
            _hub.Clients.All.SendAsync("SendMessage", "Fim");
            return Task.CompletedTask;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}