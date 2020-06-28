using GoBarber.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.DTO.Appointment
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public virtual UserDTO User { get; set; }
    }

    public class AppointmentInput
    {

    }

    public class AppointmentResult : GenericResult
    {
        public AppointmentDTO Appointment { get; set; }
        public IEnumerable<AppointmentDTO> Appointments { get; set; }
    }
}
