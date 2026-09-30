
using Microsoft.AspNetCore.Mvc;

namespace MD_AspNetCoreDemoApp.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeV3Controller : ControllerBase
    {


        [HttpGet]
        [Route("GetEmployeeList/{empName}/{anotherEmpName}")]
        public async Task<IActionResult> GetEmployeeList
            ([FromRoute] string empName , [FromRoute] string anotherEmpName)
        {
            //string empName = "JOHn";
            
            
            var empList = await getEmployees();

            //select * from emp where empname = "Peter1233";
            var count = empList.Where(x => x == empName).Count();   //0

            if(count  == 0)
            {
                return NotFound($"No employee found with the name of {empName}");
            }
            return Ok(empList);

        }




        //github.com/madanpatkota?reponame='repo1'

        ///api/employeev3/GetEmployeeListByMultiQueryParam? EN=_______ & AEN= ________

        [HttpGet]
        [Route("GetEmployeeListByMultiQueryParam")]
        public async Task<IActionResult> GetEmployeeListByMultiQueryParam
            (
            [FromQuery(Name = "EN" )] string empName,
            [FromQuery(Name = "AEN")] string anotherempName

            )
        {
            //string empName = "JOHn";


            var empList = await getEmployees();

            // x here is the string

            //select * from emp where empname = "Peter1233";
            var count = empList.Where(x => x == empName).Count();   //0

            if (count == 0)
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
