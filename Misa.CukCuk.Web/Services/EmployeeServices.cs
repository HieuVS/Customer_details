using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Misa.CukCuk.Web.Enum;
using Misa.CukCuk.Web.Modals;
using MISA.DemoAPI.Modals;

namespace Misa.CukCuk.Web.Services
{
    public class EmployeeServices
    {
        DbConnector dbConnector;
        public EmployeeServices()
        {
            dbConnector = new DbConnector();
        }
        public ServiceResult InsertEmployee(Employee employee)
        {
            ServiceResult serviceResult = new ServiceResult();
            var employeeCode = employee.EmployeeCode;
            var sql = $"SELECT EmployeeCode FROM Employee WHERE EmployeeCode = '{employeeCode}' ";
            var employeeDuplicate = dbConnector.GetDataByCommand<Employee>(sql);
            if (employeeDuplicate.Count() > 0)
            {
                return new ServiceResult()
                {
                    Data = employeeDuplicate,
                    Messenger = Properties.Resources.Error_Duplicate,
                    MisaCode = MisaServiceCode.BadRequest
                };
            }
            //Check họ tên không được để trống
            if (employee.FullName.Trim() == string.Empty)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Error_Required,
                    MisaCode = MisaServiceCode.BadRequest
                };
            }
            //SDT không được trống
            if (employee.PhoneNumber.Trim() == string.Empty)
            {
                return new ServiceResult()
                {
                    Data = null,
                    Messenger = Properties.Resources.Error_Required_PhoneNumber,
                    MisaCode = MisaServiceCode.BadRequest
                };
            }
            return new ServiceResult()
            {
                Data = dbConnector.Insert<Employee>(employee),
                Messenger = Properties.Resources.Msg_Success,
                MisaCode = MisaServiceCode.Success
            };
        }
    }
}

