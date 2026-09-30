
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MD_AspNetCoreDemoApp.Controllers
{


    //@componnet

    //we are desining the apis 

    // domain / conroller / resource    - Endpoint  - TL 
    //https://localhost:7114/api/Employee      --->  "JOHN"


    //<app-root>
    //<app-compA>
    //<app-comB>
    //https://localhost:7114/api/Employee/GetEmpName1
    //https://localhost:7114/api/Employee/geemployee2

    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : ControllerBase
    {
        //OK Reponse
        //

        [HttpGet]
        [Route("GetEmpName1")]
        public IActionResult GetEmpname1()
        {

            var a = "JOHN";
            if( a  == "JOHN")
            {
                return Ok("Employee is available");
            }
            else
            {
                return BadRequest("NOT a employee");
            }


        }


        //https://localhost:7114/Employee/GetEmpName2 
        [HttpGet]
        [Route("GetEmpName2")]
        public IActionResult abcd()
        {
            return Ok("Peter");   //
            //return "JOHN";
        }

    }
}
