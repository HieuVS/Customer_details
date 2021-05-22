using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk.Web.Modals
{
    public class Department
    {
        /// <summary>
        /// Mã Guid phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Mã Guid phòng ban dạng String
        /// </summary>
        public string DepartmentIdConstraint
        {
            get
            {
                return DepartmentId.ToString();
            }
        }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
