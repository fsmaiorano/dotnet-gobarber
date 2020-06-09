using Bogus;
using GoBarber.Data.Context;
using GoBarber.Data.Repository;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.Service.Services;
using GoBarber.Service.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoBarber.UnitTest.Services
{
    [TestClass]
    public class UserServiceUnitTest
    {
        private readonly ServiceCollection _services;
        private readonly ServiceProvider _serviceProvider;
        private readonly IUserService _userService;

        public UserServiceUnitTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<IUserService, UserService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUserRepository<>), typeof(UserRepository<>));
            services.AddDbContext<MyContext>(
             options => options.UseSqlServer("Server=localhost;user=sa;password=Password123;database=gobarber")
         );

            _services = services;
            _serviceProvider = services.BuildServiceProvider();
            _userService = _serviceProvider.GetService<IUserService>();
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

            var createdUser = _userService.Insert(user);
            Assert.IsNotNull(createdUser);
            Assert.AreEqual(user, createdUser);

            var isDeleted = _userService.Delete(createdUser.Email);
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
