
using Microsoft.AspNetCore.Mvc;

namespace MD_AspNetCoreDemoApp.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeV4Controller : ControllerBase
    {


        [HttpGet]
        [Route("GetEmployeeList/{empName}/{anotherEmpName}")]
        public async Task<IActionResult> GetEmployeeList
            ([FromRoute] string empName, [FromRoute] string anotherEmpName)
        {
            //string empName = "JOHn";

            var empList = await getEmployees();

            //select * from emp where empname = "Peter1233";


            // what is the type of x here employee
            //    Employee
            //{
            //    public int EmpId { get; set; }
            //public string EmpName { get; set; }
            //public string EmpLocation { get; set; }
            //public double EmpSalary { get; set; }

            //}


            var count = empList.Where(x => x.EmpName == empName).Count();   //0

            if (count == 0)
            {
                return NotFound($"No employee found with the name of {empName}");
            }
            return Ok(empList);


            //  1  == "1"

        }




        //github.com/madanpatkota?reponame='repo1'

        ///api/employeev3/GetEmployeeListByMultiQueryParam? EN=_______ & AEN= ________

        [HttpGet]
        [Route("GetEmployeeListByMultiQueryParam")]
        public async Task<IActionResult> GetEmployeeListByMultiQueryParam
            (
                [FromQuery(Name = "empName")] string empName,
                [FromQuery(Name = "empID")] string empID,
                [FromQuery(Name = "empLocation")] string empLocation
            )
        {

            var empList = await getEmployees();

            var count = empList.
                Where(x => x.EmpName == empName
                             && x.EmpId.ToString() == empID        // 1 --> "1"
                             && x.EmpLocation == empLocation).Count();   //0

            if (count == 0)
            {
                return NotFound($"No employee found with the name of {empName}");
            }

            else
            {
                var emp = empList.
                Where(x => x.EmpName == empName
                             && x.EmpId.ToString() == empID        // 1 --> "1"
                             && x.EmpLocation == empLocation);
                return Ok(emp);
            }

        }




        //1. YOu should not give the class as ref directly as a parameter(domain modles)

        //2 . that means you are giving the domain model related informtion to the client

        //3. Domain model into the DTOs


        //fromroute
        //fromquery
        //frombody

        [HttpGet]
        [Route("GELMQPCN")]
        public async Task<IActionResult> GetEmployeeListByMultiQueryParamWithClassName
            (
                [FromQuery] EmployeeDTO emp
            )
        {

            await Task.Delay(1000);
            return Ok(emp);
        }


        [HttpGet]
        [Route("GetEmployeeListByBodyWithClassName")]
        public async Task<IActionResult> GetEmployeeListByBodyWithClassName
            (
                [FromBody] EmployeeDTO emp
            )
        {

            await Task.Delay(1000);
            return Ok(emp);

        }







        private async Task<List<Employee>> getEmployees()
        {
            await Task.Delay(1000);
            return _store();
        }



        //github.com?location=new%20york



        private List<Employee> _store()
        {
            return new List<Employee>()
                {
                    new Employee() { EmpId = 1, EmpName = "Michel", EmpLocation = "New York", EmpSalary = 20000.89 },
                    new Employee() { EmpId = 2, EmpName = "Sarah",  EmpLocation = "London",   EmpSalary = 25000.50 },
                    new Employee() { EmpId = 3, EmpName = "Ravi",   EmpLocation = "Bangalore",EmpSalary = 18000.00 },
                    new Employee() { EmpId = 4, EmpName = "Emily",  EmpLocation = "New York", EmpSalary = 30000.75 },
                    new Employee() { EmpId = 5, EmpName = "John",   EmpLocation = "New York", EmpSalary = 22000.40 }
                };
        }




        public class EmployeeDTO
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }

            public string AadharNo {  get; set; }

            public string pancardNo { get; set; }

            public bool IsMarried {  get; set; }

            // public string EmpLocation { get; set; }
           // public double EmpSalary { get; set; }

        }





        private class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string EmpLocation { get; set; }
            public double EmpSalary { get; set; }

        }

    }
}
