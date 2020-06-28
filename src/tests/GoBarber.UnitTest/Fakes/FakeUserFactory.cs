using Bogus;
using GoBarber.Domain.Constants;
using GoBarber.Domain.Entities;
using GoBarber.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.UnitTest.Fakes
{
    public class FakeUserFactory
    {
        public static UserInput CreateUser()
        {
            var mockUser = new Faker<UserInput>()
               .RuleFor(u => u.Name, (f, u) => f.Name.FullName())
               .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
               .RuleFor(u => u.Password, (f, u) => f.Internet.Password());

            var user = mockUser.Generate();
            user.Avatar = $"https://api.adorable.io/avatars/{new Random().Next(10000)}";
            user.Role = RoleConstant.Client;

            return user;
        }
    }
}
