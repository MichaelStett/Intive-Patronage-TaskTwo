using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("/FizzBuzz")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        public class Answer
        {
            static public string ByTwo   = "Fizz";
            static public string ByThree = "Buzz";
            static public string ByNone  = "None";
        }

        // GET
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Answer.ByNone;
        }

        // GET with arg
        [HttpGet("{arg}")]
        public ActionResult<string> Get(int arg)
        {
            if(arg % 2 == 0 && arg % 3 == 0)
            {
                return (Answer.ByTwo + Answer.ByThree);
            }
            if (arg % 2 == 0)
            {
                return Answer.ByTwo;
            }
            if (arg % 3 == 0)
            {
                return Answer.ByThree;
            }

            return Answer.ByNone;
        }
    }
}
