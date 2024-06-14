using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace EmployeeManagment.Controllers
{
    [ApiController]
    [Route("empdb")]
    public class EmpDBController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public EmpDBController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataTable GetTable(string query)
        {
            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString
                ("EmployeeCon");

            MySqlDataReader myReader;
            using (MySqlConnection mySqlConnection = new MySqlConnection(sqlDataSource))
            {
                mySqlConnection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                {
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mySqlConnection.Close();

                }
            }
            return table;
        }

        [HttpGet("dbData")]
        public JsonResult getAllEmp()
        {
            string query = @"
                select * from Employee;
            ";
            DataTable table = GetTable(query);
            return new JsonResult(table);
        }


        [HttpPost("dbStoreData")]
        public JsonResult saveEmp(Employee emp)
        {
            string query = @"insert into Employee values("+emp.EmpId+",'"+emp.EmpName+"','"+emp.Company+"')";

            GetTable(query);
            return new JsonResult(emp.EmpId + " Added Succesfully");
        }

        [HttpPut("dbUpdateData")]
        public JsonResult updateEmp(Employee emp)
        {
            string query = @"
                update Employee set emp_name = '"+emp.EmpName+"',company = '"+emp.Company+"' where emp_id = "+emp.EmpId+"";

            GetTable(query);
            return new JsonResult(emp.EmpId + " Updated Succesfully");
        }

        [HttpDelete("{id}")]
        public JsonResult deleteEmp(int id)
        {
            string query = @"
                delete from Employee
                where emp_id = "+id+"";

            GetTable(query);
            return new JsonResult(id + " deleted Succesfully");
        }

    }
 }
