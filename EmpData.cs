using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment
{
    public class EmpData
    {
        List<Employee> employees = new List<Employee>();

       
        public string AddEmp(Employee emp)
        {
            Console.WriteLine(employees.GetHashCode());
            employees.Add(emp);
            return "emp added Successfully";
        }

      
        public List<Employee> GetEmployees()
        {
            Console.WriteLine(employees.GetHashCode());
            return employees;
        }

        public Employee checkEmpId(int Id)
        {
            foreach (Employee e in employees)
            {
                if (e.EmpId == Id)
                {
                    return e;
                }
            }
            return null;
        }

        public string DeleteEmpId(int Id)
        {
            Employee emp = null;
            foreach (Employee e in employees)
            {
                if (e.EmpId == Id)
                {
                    emp = e;
                }
            }
            if (emp != null)
            {
                employees.Remove(emp);
                return emp.EmpName + " sucessfull delete ";
            }
            return "User not found";
        }

        public Employee UpdateById(Employee e)
        {
            Employee emp = null;
            foreach (Employee n in employees)
            {
                if (n.EmpId == e.EmpId)
                {
                    emp = n;
                }
            }
            if (emp != null)
            {
                emp.EmpName = e.EmpName;
                emp.Company = e.Company;
                return emp;
            }
            return null;
        }
    }
}
