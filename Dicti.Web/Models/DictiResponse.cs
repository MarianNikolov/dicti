using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dicti.Web.Models
{
    public class DictiResponse<T>
    {
        public T Data { get; set; }
    }
}
