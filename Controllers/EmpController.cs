using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EmployeeManagment.Controllers
{
    [ApiController]
    [Route("emp")]
    public class EmpController : ControllerBase
    {
        public static EmpData EmpData = new EmpData();

        [HttpGet("welcome")]
        public string WelcomeEmp()
        {
            return "Emp management started";
        }

        [HttpGet("empData")]
        public Employee GiveMeEmp()
        {
            Employee emp = new Employee();
            emp.EmpId = 1;
            emp.EmpName = "Test";
            emp.Company = "ABC";

            return emp;
        }

        [HttpPost("addEmp")]
        public string AddEmp(Employee emp)
        {
            EmpData.AddEmp(emp);
            return "Emp Added Sucessfully " +emp.EmpId;
        }
      
        [HttpGet("allEmp")]
        public List<Employee> GetEmployees()
        {
            return EmpData.GetEmployees();
        }

        [HttpPost("GetEmpByID")]
        public Employee GetEmpByID(int Id)
        {
            return EmpData.checkEmpId(Id);
        }

        [HttpPost("DeleteEmp")]

        public String DeleteEmpById(int Id)
        {
            return EmpData.DeleteEmpId(Id);
        }

        [HttpPost("UpdateEmp")]

        public string UpdateById(Employee e)
        {
            Employee emp = EmpData.UpdateById(e);
            if (emp == null)
            {
                return "Emp not found";
            }
            else
                return emp.ToString();
        }
    }
}
