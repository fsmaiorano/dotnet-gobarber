using GoBarber.DTO.Appointment;
using GoBarber.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Web.ViewModels.Appointment
{
    public class AppointmentViewModel
    {
        public Int32 ProviderId { get; set; }
        public Int32 UserId { get; set; }
        public DateTime Date { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
