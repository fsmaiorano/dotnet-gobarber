using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.Domain.Interfaces
{
    public interface IUserRepository<T> where T : BaseEntity
    {
        bool teste();
    }
}
