using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DotnetAssignment.Controllers
{
    [ApiController]
    [Route("api/external")]
    public class ExternalApiController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CallFreeApi()
        {
            var url = "https://randomuser.me/api/";

            using var client = new HttpClient();
            var responseString = await client.GetStringAsync(url);

            var responseJson = JsonSerializer.Deserialize<object>(responseString);

            return Ok(new
            {
                url = url,
                method = "GET",
                response = responseJson
            });
        }
    }
}
