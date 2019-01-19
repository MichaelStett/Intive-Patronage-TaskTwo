using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [Route("/CallFizzBuzz")]
    [ApiController]
    public class CallController : ControllerBase
    {
        // POST
        [HttpPost]
        public ActionResult<string> PostCall(ParamItem TempItem)
        {
            var client = new RestClient("http://localhost:5000/");
            var request = new RestRequest($"fizzbuzz/{TempItem.Param}", Method.GET);

            var response = client.Execute(request);

            return response.Content.Replace("\"", "");
        }
    }
}
