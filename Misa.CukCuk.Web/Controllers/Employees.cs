using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Misa.CukCuk.Web.Services;
using MISA.DemoAPI.Modals;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Misa.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Employees : ControllerBase
    {
        DbConnector dbConnector;
        public Employees()
        {
            dbConnector = new DbConnector();
        }
        // GET: api/<Employees>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dbConnector.GetAllData<Employee>());
        }

        // GET api/<Employees>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(dbConnector.GetById<Employee>(id));
        }
        [HttpGet("search")]
        public IActionResult Get([FromQuery] string code, [FromQuery] string phoneNumber)
        {
            return Ok(dbConnector.GetDataByCodeandPhone<Employee>(code, phoneNumber));
        }
        //truyen tham so va lay du lieu tu store thay cho viec phai select nhieu lan

        // POST api/<Employees>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            EmployeeServices employeeServices = new EmployeeServices();
            var res = employeeServices.InsertEmployee(employee);
            switch (res.MisaCode)
            {
                case Enum.MisaServiceCode.BadRequest:
                    return BadRequest(res);
                case Enum.MisaServiceCode.Success:
                    return Ok(res);
                case Enum.MisaServiceCode.Exception:
                    return StatusCode(500);
                default:
                    return Ok();
            }
               
           // return Ok(dbConnector.Insert<Employee>(employee));


        }

        

        // PUT api/<Employees>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Employees>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
