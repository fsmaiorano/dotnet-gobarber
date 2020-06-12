using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Domain.Interfaces
{
    public interface IAuthenticationRepository<T> where T : BaseEntity
    {
        T GetByUserId(int userId);
    }
}
