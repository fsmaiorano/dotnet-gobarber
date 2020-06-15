using Bogus;
using GoBarber.Data.Context;
using GoBarber.Data.Repository;
using GoBarber.Data.UnitOfWork;
using GoBarber.Domain.Constants;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.Service.Services.Authentication;
using GoBarber.Service.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoBarber.UnitTest.Services
{
    [TestClass]
    public class AuthenticationServiceUnitTest
    {
        private readonly ServiceCollection _services;
        private readonly ServiceProvider _serviceProvider;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationServiceUnitTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IAuthenticationRepository), typeof(AuthenticationRepository));
            services.AddDbContext<MyContext>(
             options => options.UseSqlServer("Server=localhost;user=sa;password=Password123;database=gobarber")
         );

            _services = services;
            _serviceProvider = services.BuildServiceProvider();

            _userService = _serviceProvider.GetService<IUserService>();
            _authenticationService = _serviceProvider.GetService<IAuthenticationService>();
        }

        [TestMethod]
        public void AuthenticateUser()
        {
            var mockUser = new Faker<UserEntity>()
            .RuleFor(u => u.Name, (f, u) => f.Name.FirstName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
            .RuleFor(u => u.Password, (f, u) => f.Internet.Password());

            var user = mockUser.Generate();

            user.Role = RoleConstant.Client;

            var createdUser = _userService.Insert(user);
            Assert.IsNotNull(createdUser);
            Assert.AreEqual(user, createdUser);

            var doLogin = _authenticationService.SignIn(user.Email, user.Password);
            Assert.IsNotNull(doLogin.Token); 

            var authenticated = _authenticationService.GetByUserId(createdUser.Id);
            Assert.IsNotNull(authenticated);
        }

    }
}
