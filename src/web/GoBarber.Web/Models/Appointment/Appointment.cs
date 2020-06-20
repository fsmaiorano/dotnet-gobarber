using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Web.Models.Appointment
{
    public class Appointment
    {
        public Int32 ProviderId { get; set; }
        public Int32 UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
