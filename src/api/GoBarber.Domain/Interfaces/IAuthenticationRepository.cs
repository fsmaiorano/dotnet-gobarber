using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.Domain.Interfaces
{
    public interface IAuthenticationRepository: IRepository<UserTokenEntity>
    {
        UserTokenEntity GetByUserId(int userId);
    }
}
