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
    public class UserRepository<T> : IUserRepository<T> where T : UserEntity
    {
        protected readonly MyContext _context;
        private DbSet<UserEntity> _dataset;

        public UserRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<UserEntity>();
        }

        public bool Delete(string email)
        {
            try
            {
                var result = _dataset.SingleOrDefault(p => p.Email.Equals(email));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Select(string email)
        {
            try
            {
                return (T)_dataset.SingleOrDefault(p => p.Email.Equals(email));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
