using Microsoft.AspNetCore.Mvc;

namespace MD_AspNetCoreDemoApp.Controllers
{


    //api/EmployeeV1/GetEmpList   

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeV1Controller : ControllerBase
    {


        EmployeeV1Repository employeeV1Repository;

        public EmployeeV1Controller()
        {
            //Console.WriteLine("hello world");
            employeeV1Repository = new EmployeeV1Repository();
        }

        [HttpGet]
        [Route("GetEmpList")]
        public async Task<IActionResult> GetAllEmp()
        {
            await Task.Delay(1000);
            //_store
            var list = employeeV1Repository.EmployeesList();
            return Ok(list);
        }


        [HttpGet]
        [Route("GetEmpList1")]
        public async Task<IActionResult> GetAllEmp1()
        {
            await Task.Delay(1000);
            var list = employeeV1Repository.EmployeesList();
            return Ok(list);
        }
        //private List<Employee> _store()
        //{
        //    return new List<Employee>()
        //        {
        //            new Employee() { Id = 1, Name = "Michel", Department = "Admin" },
        //            new Employee() { Id = 2, Name = "Michel", Department = "Admin" },
        //            new Employee() { Id = 3, Name = "Michel", Department = "Admin" },

        //        };
        //}

    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeV1Repository
    {
        public List<Employee> EmployeesList()
        {
            return new List<Employee>()
                {
                    new Employee() { Id = 1, Name = "Michel", Department = "Admin" },
                    new Employee() { Id = 2, Name = "Michel", Department = "Admin" },
                    new Employee() { Id = 3, Name = "Michel", Department = "Admin" },

                };
        }
    }



}
