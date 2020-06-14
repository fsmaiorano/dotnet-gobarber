using GoBarber.Data.Context;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public bool Delete(Int32 id)
        {
            try
            {
                var result = _dataset.SingleOrDefault(p => p.Id.Equals(id));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                //_context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Insert(T item)
        {
            try
            {
                item.CreatedAt = DateTime.UtcNow;
                _dataset.Add(item);

                //_context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public bool Exist(Int32 id)
        {
            return _dataset.Any(p => p.Id.Equals(id));
        }

        public T Select(Int32 id)
        {
            try
            {
                return _dataset.SingleOrDefault(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<T> Select()
        {
            try
            {
                return _dataset.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Update(T item)
        {
            try
            {
                var result = _dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
                if (result == null)
                    return null;

                item.UpdatedAt = DateTime.UtcNow;
                item.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                //_context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
