using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Web.Models
{
    public class GenericResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
    }
}
