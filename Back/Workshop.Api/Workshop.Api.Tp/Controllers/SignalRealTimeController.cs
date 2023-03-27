using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using Workshop.Api.Tp.Models.Requests;
using Workshop.Api.Tp.Models.SignalR;

namespace Workshop.Api.Tp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRealTimeController : ControllerBase
    {
        private IHubContext<AppHub> _hub;
        private readonly HttpClient _httpClient;
        private readonly Newtonsoft.Json.JsonSerializer _serializer;
        public SignalRealTimeController(IHubContext<AppHub> hub, HttpClient httpClient)
        {
            _hub = hub;
            _httpClient = new HttpClient();
        }

        [HttpPost("Notify")]
        public async Task<ActionResult> Notify([FromBody] NotifyRequests request)
        {
            await _hub.Clients.All.SendAsync("camundaMessageHub", request);
            return this.Ok();
        }

        [HttpGet]
        public async Task<ActionResult> CheckFunctionality()
        {
            var sensorFunctionality = false;
            Random random = new Random();
            if (random.NextDouble() < 0.9)
            {
                sensorFunctionality = true;
            }

            return this.Ok(sensorFunctionality);
        }

        [HttpPost("SensorCheck/{sensorId}")]
        public async Task<ActionResult> Check(int sensorId)
        {
            var processId = "Demo-Process";
            var url = $"http://localhost:8080/engine-rest/process-definition/key/{processId}/start";
            var bodyData = new { variables = new { }, businessKey = sensorId.ToString() };
            var response = await _httpClient.PostAsync(url,new StringContent(JsonConvert.SerializeObject(bodyData), Encoding.UTF8, "application/json" ));
            var content  = await response.Content.ReadAsStringAsync(); 

            return this.Ok();
        }
    }
}
