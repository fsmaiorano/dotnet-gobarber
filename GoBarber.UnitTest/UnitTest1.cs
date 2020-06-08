using GoBarber.Application;
using GoBarber.Data.Context;
using GoBarber.Data.Repository;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.Service.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoBarber.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ServiceCollection _services;
        private readonly ServiceProvider _serviceProvider;
        private readonly IUserService _userService;

        public UnitTest1()
        {
            var services = new ServiceCollection();
            services.AddTransient<IUserService, UserService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddDbContext<MyContext>(
             options => options.UseSqlServer("Server=localhost;user=sa;password=Password123;database=gobarber")
         );

            _services = services;
            _serviceProvider = services.BuildServiceProvider();
            _userService = _serviceProvider.GetService<IUserService>();
        }


        [TestMethod]
        public void TestMethod1()
        {
            //var builder = WebHost
            //    .CreateDefaultBuilder()
            //    .UseStartup<Startup>();

            //var server = new TestServer(builder);
            //var client = server.CreateClient();

            var user = new UserEntity();
            _userService.Post(user);
        }
    }
}
