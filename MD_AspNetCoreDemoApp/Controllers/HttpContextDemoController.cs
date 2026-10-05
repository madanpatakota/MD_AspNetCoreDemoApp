using Microsoft.AspNetCore.Mvc;

namespace MD_AspNetCoreDemoApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HttpContextDemoController : ControllerBase
    {

        //[HttpPost]
        //[Route("ShowContext/{Id}")]
        //public IActionResult ShowContext()
        //{

        //    //var context = HttpContext;
        //    return Ok();

        //    //return Ok(new
        //    //{
        //    //    MyRouterID = Id,
        //    //    QueryAGe = age,
        //    //    QueryLocation = location,
        //    //    User = user
        //    //});


        //}
        [HttpPost]
        [Route("ShowContext/{Id}")]
        public IActionResult ShowContext(
            [FromRoute] int Id,
            [FromQuery] int age,
            [FromQuery] string location,
            [FromBody] UserDTO user,
            [FromHeader(Name ="MyCollegeName")] string collegeName)
        {

            var context = HttpContext;


            var headers = context.Request.Headers;
            var body    = context.Request.Body;
            var path    = context.Request.Path;
            var query   = context.Request.Query;


            context.Response.Headers.Append("demo-response", "THis is from asp.entcore ");
            context.Response.Headers.Append("demo-messagestatus", "received all data");


            return Ok(new
            {
                MyRouterID = Id,
                QueryAGe = age,
                QueryLocation = location,
                User = user
            });


        }


        public class UserDTO
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}
