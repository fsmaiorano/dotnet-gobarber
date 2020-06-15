using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Domain.Entities
{
    public class AppointmentEntity : BaseEntity
    {
        public Int32 ProviderId { get; set; }
        public virtual UserEntity Provider { get; set; }
        public Int32 UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public DateTime Date { get; set; }
    }
}
