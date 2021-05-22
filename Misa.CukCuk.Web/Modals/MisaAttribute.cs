using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.CukCuk.Web.Modals
{
    public class MisaAttribute
    {
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }
}
