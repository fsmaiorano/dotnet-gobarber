using GoBarber.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;
        public UnitOfWork(MyContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
        }
    }
}
