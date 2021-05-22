using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk.Web.Enum
{
    public enum MisaServiceCode
    {
        /// <summary>
        /// Lỗi về dữ liệu không hợp lệ
        /// </summary>
        BadRequest = 400,
        Success = 200,
        Exception = 500
    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 0,
    }
}
