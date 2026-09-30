
using Microsoft.AspNetCore.Mvc;
using static MD_AspNetCoreDemoApp.Controllers.EmployeeV4Controller;
using static MD_AspNetCoreDemoApp.Controllers.Employeev5Controller;

namespace MD_AspNetCoreDemoApp.Controllers
{




    [ApiController]
    [Route("api/[controller]")]
    public class Employeev5Controller  : ControllerBase
    {
        public Employeev5Controller() { }


        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] NewEmployeeDTO nDTO)
        {
            //
            //your chocice --- C# .net
            var result = await NewEmployee(nDTO);

            if (result == "Failed")
            {
                return BadRequest("Employee details are not good . please give proper details");
            }

            return Created("api/employeev5/CreateEmloyee" , "Created record succsssully"); // "201"  --> 1 hour for vamsi 

            // 401 , 400 , 403 , 

            //
           
        }


        private async Task<string> NewEmployee(NewEmployeeDTO newEmplluee)
        {
            await Task.Delay(1000);

            if (string.IsNullOrEmpty(newEmplluee.Name))
            {

                return "Failed";
            }
            return "Success";
        }





        // needs the clarity  - do u want to fetch , create , updation (full , partial) , deletion

        [HttpPut]
        [Route("updateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int Id, [FromBody] UpdateEmployeeDTO uDTO)
        {

            await Task.Delay(1000);

            //select * from employees where emploation = "UK";  // 1 or lot of records

            // where if i want to get the first record ---> Top 1

            var emp = _store().Where(x => x.EmpId == Id).FirstOrDefault(); // 1 MIchal details

            if ( emp != null)
            {
                emp.EmpName = uDTO.Name;
                emp.EmpSalary =  Convert.ToDouble(uDTO.Salary);
                emp.EmpLocation = uDTO.Location;


                //check here _store() 
                return Ok($"{ emp.EmpName} is created ..........");
            }
            else
            {
                return BadRequest("Please check your id ONCe. your id is not avaible");
            }


            // you have to give these details to the DB
            // as of now i am not connecting to the db . just imagine

           



        }



        // 10 columns
        // update __________________ u can entiry update rhe reord


        // update  ----------------- limited name , salary 


        [HttpPatch]
        [Route("PatchEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int Id, [FromBody] PatchEmployeeDTO pDTO)
        {

            await Task.Delay(1000);

            //select * from employees where emploation = "UK";  // 1 or lot of records

            // where if i want to get the first record ---> Top 1

            var emp = _store().Where(x => x.EmpId == Id).FirstOrDefault(); // 1 MIchal details

            if (emp != null)
            {
                emp.EmpName = pDTO.Name;
                emp.EmpLocation = pDTO.Location;

                // check the _store() object
                return Ok($"{emp.EmpName} is updated ..........");
            }
            else
            {
                return BadRequest("Please check your id ONCe. your id is not avaible");
            }


            // you have to give these details to the DB
            // as of now i am not connecting to the db . just imagine





        }



        [HttpDelete]
        [Route("DeleteEmployee/{Id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int Id)
        {

            await Task.Delay(1000);

            var employees = _store();

            var emp = employees.FirstOrDefault(x=>x.EmpId == Id); // 1 MIchal details

            if (emp != null)
            {
                var obj = employees.Remove(emp);
                return Ok($"Record delted {emp.EmpName}");
                //once you
            }
            else
            {
                return BadRequest("Please check your id ONCe. your id is not avaible");
            }

        }






















        //in the entire worls everyone have the name. that is mandaotyr



        //One new emp joined in the software company .here hr creting the his details in the companydb
        public class NewEmployeeDTO
        {
            //"" one kind of value
            public string? Name { get; set; }          //it can contains the null value
            public string Location { get; set; }
            public decimal Salary { get; set; }
            public int Age { get; set; }
            public DateTime JoiningDate { get; set; }
            public DateTime? DOB { get; set; }       // i want to mannually gives the null value. yes ican
            public string? StreetAdress { get; set; }

        }

        public class PatchEmployeeDTO
        {
            public string? Name { get; set; }          //it can contains the null value
            public string Location { get; set; }


        }



        public class UpdateEmployeeDTO
        {
            public string? Name { get; set; }          //it can contains the null value
            public string Location { get; set; }
            public decimal Salary { get; set; }

        }


        public class EmployeeDTO
        {
            public string EmpName { get; set; }
            public string Location { get; set; }
            public double Salary { get; set; }

        }


        private List<Employee> _store()
        {
            return new List<Employee>()
                {
                    new Employee() { 
                        EmpId = 1, 
                        EmpName = "Michel", 
                        EmpLocation = "New York", 
                        EmpSalary = 20000.89 },
                    
                    new Employee() { EmpId = 2, EmpName = "Sarah",  EmpLocation = "London",   EmpSalary = 25000.50 },
                    new Employee() { EmpId = 3, EmpName = "Ravi",   EmpLocation = "Bangalore",EmpSalary = 18000.00 },
                    new Employee() { EmpId = 4, EmpName = "Emily",  EmpLocation = "New York", EmpSalary = 30000.75 },
                    new Employee() { EmpId = 5, EmpName = "John",   EmpLocation = "New York", EmpSalary = 22000.40 }
                };
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
