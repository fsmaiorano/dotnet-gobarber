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
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
