using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace WebApi2.Controllers
{
    [Route("/CallFizzBuzz")]
    [ApiController]
    public class CallFizzBuzzController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var client = new RestClient("http://localhost:5000/");
            var request = new RestRequest("fizzbuzz/", Method.GET);
            var response = client.Execute(request);

            return response.Content.Replace("\"", "");
        }

        [HttpGet("{arg}")]
        public ActionResult<string> Get(int arg)
        {
            var client = new RestClient ("http://localhost:5000/");
            var request = new RestRequest ($"fizzbuzz/{arg}", Method.GET);
            var response = client.Execute(request);

            return response.Content.Replace("\"", "");
        }
    }
}
