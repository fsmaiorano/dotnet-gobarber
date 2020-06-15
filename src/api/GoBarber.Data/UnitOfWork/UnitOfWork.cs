using GoBarber.Data.Context;
using GoBarber.Data.Repository;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        IUserRepository UserRepository { get; set; }
        IAuthenticationRepository AuthenticationRepository { get; set; }
        IAppointmentRepository AppointmentRepository { get; set; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;
        private IUserRepository _userRepository;
        private IAuthenticationRepository _authenticationRepository;
        private IAppointmentRepository _appointmentRepository;

        public UnitOfWork(MyContext context,
                            IUserRepository userRepository,
                            IAuthenticationRepository authenticationRepository,
                            IAppointmentRepository appointmentRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _appointmentRepository = appointmentRepository;
            _authenticationRepository = authenticationRepository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
        }

        IUserRepository IUnitOfWork.UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }

            set { }
        }

        IAuthenticationRepository IUnitOfWork.AuthenticationRepository
        {
            get
            {

                if (_authenticationRepository == null)
                {
                    _authenticationRepository = new AuthenticationRepository(_context);
                }
                return _authenticationRepository;
            }

            set { }
        }

        IAppointmentRepository IUnitOfWork.AppointmentRepository
        {
            get
            {

                if (_appointmentRepository == null)
                {
                    _appointmentRepository = new AppointmentRepository(_context);
                }
                return _appointmentRepository;
            }

            set { }
        }
    }
}
