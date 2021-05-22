using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Misa.CukCuk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Department : ControllerBase
    {
        string connectionString = "User Id=nvmanh;Host=103.124.92.43;Database=Ms2_13_VSH; port=3306;password =12345678;Character Set=utf8";
        IDbConnection dbConnection;
        public Department()
        {
            dbConnection = new MySqlConnection(connectionString);
        }
        // GET: api/<Employees>
        [HttpGet]
        public List<Department> Get()
        {
            List<Department> departments = new List<Department>();
            //lay du lieu
            departments = dbConnection.Query<Department>("Proc_GetDepartment", commandType: CommandType.StoredProcedure).ToList();

            return departments;
        }
    }
}
