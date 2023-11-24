using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly ILogger<ServiceRequestsController> _logger;

        public ServiceRequestsController(ILogger<ServiceRequestsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetData")]
        public async Task<IActionResult> Get()
        {
            var result = await ConnectToApiV2();

            return Ok(result);
        }

        private async Task<string> ConnectToApiV2()
        {
            var url = "https://localhost:5002/WeatherForecast";

            var client = new RestClient();

            var request = new RestRequest(url, Method.Get);
            request.AddHeader("accept", "application/json");
            
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Console.Out.WriteLine(response.Content);
                return response.Content;
            }
            else
            {
                Console.Out.WriteLine(response.ErrorMessage);
                return response.ErrorMessage;
            }
        }

        private async Task<string> ConnectToApi()
        {
            var url = "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random";

            var client = new RestClient();

            var request = new RestRequest(url, Method.Get);
            request.AddHeader("accept", "application/json");
            request.AddHeader("X-RapidAPI-Key", "1f7fb1d808mshc459cc97b1b1743p10218fjsn78d4d7f202bc");
            request.AddHeader("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                Console.Out.WriteLine(response.Content);
                return response.Content;
            }
            else
            {
                Console.Out.WriteLine(response.ErrorMessage);
                return response.ErrorMessage;
            }
        }
    }
}
