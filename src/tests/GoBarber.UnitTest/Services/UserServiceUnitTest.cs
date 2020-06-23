using Bogus;
using GoBarber.Data.Context;
using GoBarber.Data.Repository;
using GoBarber.Data.UnitOfWork;
using GoBarber.Domain.Constants;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.Service.Services;
using GoBarber.Service.Services.Appointment;
using GoBarber.Service.Services.Authentication;
using GoBarber.Service.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GoBarber.UnitTest.Services
{
    [TestClass]
    public class UserServiceUnitTest
    {
        private readonly ServiceCollection _services;
        private readonly ServiceProvider _serviceProvider;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAppointmentService _appointmentService;

        public UserServiceUnitTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IAuthenticationRepository), typeof(AuthenticationRepository));
            services.AddScoped(typeof(IAppointmentRepository), typeof(AppointmentRepository));
            services.AddDbContext<MyContext>(
             options => options.UseSqlServer("Server=localhost;user=sa;password=Password123;database=gobarber")
         );

            _services = services;
            _serviceProvider = services.BuildServiceProvider();

            _userService = _serviceProvider.GetService<IUserService>();
            _authenticationService = _serviceProvider.GetService<IAuthenticationService>();
            _appointmentService = _serviceProvider.GetService<IAppointmentService>();
        }

        //var builder = WebHost
        //    .CreateDefaultBuilder()
        //    .UseStartup<Startup>();

        //var server = new TestServer(builder);
        //var client = server.CreateClient();

        [TestMethod]
        public void CreateUser()
        {
            var mockUser = new Faker<UserEntity>()
            .RuleFor(u => u.Name, (f, u) => f.Name.FirstName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
            .RuleFor(u => u.Password, (f, u) => f.Internet.Password());

            var user = mockUser.Generate();
            user.Avatar = $"https://api.adorable.io/avatars/{new Random().Next(10000)}";
            user.Role = RoleConstant.Client;
            
            var createdUser = _userService.Insert(user);
            Assert.IsNotNull(createdUser);
            Assert.AreEqual(user, createdUser);
        }

        [TestMethod]
        public void UpdateUser()
        {
            var mockUser = new Faker<UserEntity>()
            .RuleFor(u => u.Name, (f, u) => f.Name.FirstName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
            .RuleFor(u => u.Password, (f, u) => f.Internet.Password());

            var user = mockUser.Generate();
            user.Avatar = $"https://api.adorable.io/avatars/{new Random().Next(10000)}";
            user.Role = RoleConstant.Client;

            var createdUser = _userService.Insert(user);
            Assert.IsNotNull(createdUser);
            Assert.AreEqual(user, createdUser);

            createdUser.Name = $"{createdUser.Name}_edited";

            var updatedUser = _userService.Update(createdUser);
            Assert.AreEqual(updatedUser.Name, createdUser.Name);
        }

        [TestMethod]
        public void DeleteUserByEmail()
        {
            var mockUser = new Faker<UserEntity>()
            .RuleFor(u => u.Name, (f, u) => f.Name.FirstName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
            .RuleFor(u => u.Password, (f, u) => f.Internet.Password());

            var user = mockUser.Generate();
            user.Avatar = $"https://api.adorable.io/avatars/{new Random().Next(10000)}";
            user.Role = RoleConstant.Client;

            var createdUser = _userService.Insert(user);
            Assert.IsNotNull(createdUser);
            Assert.AreEqual(user, createdUser);

            var isDeleted = _userService.Delete(createdUser.Id);
            Assert.IsTrue(isDeleted);
        }


        [TestMethod]
        public void ListAllUsers()
        {
            var users = _userService.SelectAll();
            Assert.IsNotNull(users);
        }
    }
}
