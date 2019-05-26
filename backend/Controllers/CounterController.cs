using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private IHubContext<HubMessages> _hub;
        private MyBackgroundWorker _worker;

        public CounterController(IHubContext<HubMessages> hub)
        {
            _hub = hub;
            //_worker = worker;
        }
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //_worker.DoAsync(id);
            _hub.Clients.All.SendAsync("Message", "Valor recebido: "+ id);
            for (int i = id; i > 0; i--)
                _hub.Clients.All.SendAsync("Message", i.ToString());
            _hub.Clients.All.SendAsync("Message", "Fim");

            return new JsonResult("Iniciando contagem até: " + id);
        }

    }
}
