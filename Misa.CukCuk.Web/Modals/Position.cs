using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk.Web.Modals
{
    public class Position
    {
        /// <summary>
        /// Mã công việc kiểu Guid
        /// </summary>
        public Guid PositionId { get; set; }
        /// <summary>
        /// Mã Guid vị trí công việc dạng String
        /// </summary>
        public string PositionIdConstraint
        {
            get
            {
                return PositionId.ToString();
            }
        }
        /// <summary>
        /// Tên vị trí công việc
        /// </summary>
        public string PositionName { get; set; }
    }
}
