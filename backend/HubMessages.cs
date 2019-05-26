using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace backend
{
    public class HubMessages : Hub
    {
        public Task SendMessage( string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
            return Clients.All.SendAsync("ReceiveMessage","Msg recebida:"+ message);
        }

        public async Task SendMessages(int total)
        {
            System.Diagnostics.Debug.WriteLine(total);
            for (int i = total; i == 0; i--)
                await Clients.All.SendAsync("SendMessage", i.ToString());
            await Clients.All.SendAsync("ReceiveMessage", "Fim");
        }
    }
}