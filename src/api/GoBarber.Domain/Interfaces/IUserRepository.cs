using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.Domain.Interfaces
{
    public interface IUserRepository<T> where T : BaseEntity
    {
        T GetByEmail(string email);
        bool DeleteByEmail(string email);
    }
}
