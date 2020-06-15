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
        IUserRepository<UserEntity> UserRepository { get; set; }
        IAuthenticationRepository<UserTokenEntity> AuthenticationRepository { get; set; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;
        private IRepository<UserEntity> _repository;
        private IUserRepository<UserEntity> _userRepository;
        private IAuthenticationRepository<UserTokenEntity> _authenticationRepository;

        public UnitOfWork(MyContext context, IRepository<UserEntity> repository, IUserRepository<UserEntity> userRepository, IAuthenticationRepository<UserTokenEntity> authenticationRepository)
        {
            _context = context;
            _repository = repository;
            _userRepository = userRepository;
            _authenticationRepository = authenticationRepository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
        }

        IUserRepository<UserEntity> IUnitOfWork.UserRepository
        {
            get
            {

                if (_userRepository == null)
                {
                    _userRepository = new UserRepository<UserEntity>(_context);
                }
                return _userRepository;
            }

            set { }
        }

        IAuthenticationRepository<UserTokenEntity> IUnitOfWork.AuthenticationRepository
        {
            get
            {

                if (_authenticationRepository == null)
                {
                    _authenticationRepository = new AuthenticationRepository<UserTokenEntity>(_context);
                }
                return _authenticationRepository;
            }

            set { }
        }
    }
}
