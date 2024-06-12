namespace EmployeeManagment
{
    public class Employee
    {
        public int EmpId{  get; set; }
        public string? EmpName { get; set; }
        public string? Company {  get; set; }
        public string ToString()
        {
            return EmpId + " " + EmpName + " " + Company + " ";
        }
    }
}
