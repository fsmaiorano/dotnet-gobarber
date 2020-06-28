using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Insert(T item);

        T Update(T item);

        bool Delete(Int32 id);

        T GetById(Int32 id);

        IEnumerable<T> Get();

        bool Exist(Int32 id);
    }
}
