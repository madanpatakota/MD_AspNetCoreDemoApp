
using Microsoft.AspNetCore.Mvc;

namespace MD_AspNetCoreDemoApp.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeV2Controller : ControllerBase
    {


        //https://localhost:5000/api/EmployeeV2/GetEmployee
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployeeName()
        {

            await Task.Delay(1000);
            return Ok(new  { Id = 1 , Name = "विष्णु , Hello,தமிழ்,हिंदी,ಕನ್ನಡ " });

        }




        [HttpGet]
        [Route("GetEmployeeList")]
        public async Task<IActionResult> GetEmployeeList()
        {
            string empName = "JOHn";
            var empList = await getEmployees();

            //select * from emp where empname = "Peter1233";
            var count = empList.Where(x => x == empName).Count();   //0

            if(count  == 0)
            {
                return NotFound($"No employee found with the name of {empName}");
            }
            return Ok(empList);

        }


        private async Task<List<string>> getEmployees()
        {
            await Task.Delay(1000);
            return _store();
        }


        private List<string> _store()
        {
            return new List<string> { "JOHn", "peter", "Peter senior"};
        }

    }
}
