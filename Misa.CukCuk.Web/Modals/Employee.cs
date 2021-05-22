using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Misa.CukCuk.Web.Modals;

namespace MISA.DemoAPI.Modals
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string Id
        {
            get
            {
                return EmployeeID.ToString();
            }
        }
        
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [Required]
        public String EmployeeCode { get; set; }
        
        public String FullName { get; set; }
        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public DateTime? DateBirth { get; set; }
        public int? Gender { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String JobStatus { get; set; }
        public int? Salary { get; set; }
        public String IdentityNumber { get; set; }
        public String IdNumPlace { get; set; }
        public DateTime? IdNumDate { get; set; }
        public String TaxNumber { get; set; }
        public String Address { get; set; }
        public DateTime? JoinDate { get; set; }

        public Guid DepartmentId { get; set; }

        public String DepartmentName { get; set; }

        public Guid PositionId { get; set; }
        public String PositionName { get; set; }

    }
}
