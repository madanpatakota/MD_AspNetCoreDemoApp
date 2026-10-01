using Microsoft.AspNetCore.Mvc;

namespace MD_AspNetCoreDemoApp.Controllers
{
    public interface IEmployeeV2Repository
    {
        List<Employeev2> EmployeesList();
    }

    public class EmployeeV2Repository : IEmployeeV2Repository
    {
        public EmployeeV2Repository()
        {
        }
        public List<Employeev2> EmployeesList()
        {
            return new List<Employeev2>()
                {
                    new Employeev2() { Id = 1, Name = "Michel", Department = "Admin" },
                    new Employeev2() { Id = 2, Name = "Michel", Department = "Admin" },
                    new Employeev2() { Id = 3, Name = "Michel", Department = "Admin" },

                };
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeV2Controller : ControllerBase
    {
        //EmployeeV2Repository employeeV2Repository;

        IEmployeeV2Repository _IEmpV2;


        //asp.netor will give me the new EmployeeV2Repository()
        public EmployeeV2Controller(IEmployeeV2Repository IEmpv2)
        {
            //iemp = new EmployeeV2Repository();
            
            _IEmpV2 = IEmpv2;

            Console.WriteLine("hello world");
        }

        [HttpGet]
        [Route("GetEmpList")]
        public async Task<IActionResult> GetAllEmp()
        {
            await Task.Delay(1000);
            //_store
            var list = _IEmpV2.EmployeesList();
            return Ok(list);
        }

        [HttpGet]
        [Route("GetEmpList1")]
        public async Task<IActionResult> GetAllEmp1()
        {
            await Task.Delay(1000);
            var list = _IEmpV2.EmployeesList();
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

    public class Employeev2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }



    
   



}
