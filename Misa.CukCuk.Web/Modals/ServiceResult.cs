using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Misa.CukCuk.Web.Enum;

namespace Misa.CukCuk.Web.Modals
{
    public class ServiceResult
    {
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Thông báo
        /// </summary>
        public string Messenger { get; set; } 
        /// <summary>
        /// Mã kết quả
        /// </summary>
        public MisaServiceCode MisaCode { get; set; }
    }
}
