using GoBarber.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.DTO.Appointment
{
    public class AppointmentDTO
    {
        public Int32 ProviderId { get; set; }
        public Int32 UserId { get; set; }
        public DateTime Date { get; set; }
        public virtual UserDTO User { get; set; }
    }

    public class AppointmentInput
    {

    }

    public class AppointmentResult : GenericResult
    {
        public IEnumerable<AppointmentDTO> Appointments { get; set; }
    }
}
