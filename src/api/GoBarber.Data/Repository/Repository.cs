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
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly MyContext _context;
        private readonly DbSet<T> _dataset;
        public Repository(MyContext context)
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
                return false;
            }
        }

        public T Insert(T item)
        {
            try
            {
                item.CreatedAt = DateTime.UtcNow;
                _dataset.Add(item);
            }
            catch (Exception ex)
            {
                return null;
            }

            return item;
        }

        public bool Exist(Int32 id)
        {
            return _dataset.Any(p => p.Id.Equals(id));
        }

        public T GetById(Int32 id)
        {
            try
            {
                return _dataset.SingleOrDefault(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _dataset.ToList();
            }
            catch (Exception ex)
            {
                return null;
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
            }
            catch (Exception ex)
            {
                return null;
            }

            return item;
        }
    }
}
