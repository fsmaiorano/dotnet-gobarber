using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoBarber.Domain.Entities
{
    public class UserTokenEntity : BaseEntity
    {
        public string Token { get; set; }
        public Int32 UserId { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
