using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MD_AspNetCoreDemoApp.Controllers.FirstStep
{


    //Client needs the address (which route client has to be connect)


    // house in bangolroe

    //get and set

    //Mapsurl
    //https://localhost:7114/DemoV1

    //MOto


    //Client ---> which kind of operation is important 

    // Get , post , put , patch or delete  [http verbs]

    //https://localhost:7114/DemoV1
    //Just Normal Class 
    [ApiController]
    [Route("DemoV1")]
    public class DemoV1Controller  : ControllerBase
    {
        //just normal method


        //[HttpGet]   // this is the method ---> which is taking res to give the data to client
        //public string Get()
        //{
        //    return "JOHN";
        //}


        //https://localhost:7114/DemoV1/GetJOHNEmp
        [HttpGet]   // this is the method ---> which is taking res to give the data to client
        [Route("GetJOHNEmp")]
        public async Task<IActionResult> GetEmployee()
        {
            string str = "JOHN";
            
            //please be wait here some time 5 secs as str needs to be update
            
            await Task.Delay(1000).ContinueWith((task)=> { str = ""; } ) ;


            if (str.Length == 0)
            {
                str = "NO Name";
                return BadRequest(str);
            }

            else
            {
                str = str + "Emp avaiblel";
                return Ok(str);
            }
            
            
            //return str;   // "Robert"
        }




















        //https://localhost:7114/DemoV1/GetPETEREmp
        [HttpGet]   // this is the method ---> which is taking res to give the data to client
        //[Route("GetE")]
        [Route("GetPETEREmp")]
        public async Task<string> GetEmployee1()
        {

            string str = "PETER Son";
            
            await Task.Delay(5000).ContinueWith((task)=> str = "Peter Father");    // Please wait here
                                                                   // 
            return str;
        }
    }
}


//attribute  -- which gives information about the class or method or parameter over here

//1. I understand this is a normacl cshrp class
//2. I am having the method

// Goal : I need to prepare the API-spefic Behaviour


//API --> Response to client.


// you have to give the instructoin from asp.netcore to the server(Kesterl)


//Client ---> Browser  , swagger tool , Postman 


