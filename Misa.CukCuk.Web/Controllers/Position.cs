using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.DemoAPI.Modals;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Misa.CukCuk.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Position : ControllerBase
    {
        DbConnector dbConnector;
        public Position()
        {
            dbConnector = new DbConnector();
        }
        // GET: api/<Employees>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dbConnector.GetAllData<Position>());
        }
    }
}
