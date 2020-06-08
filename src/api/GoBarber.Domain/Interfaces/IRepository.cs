using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Int32 id);
        Task<T> SelectAsync(Int32 id);  
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Int32 id);
    }
}
