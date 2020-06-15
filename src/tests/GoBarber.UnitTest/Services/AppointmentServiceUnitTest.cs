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
    public class AppointmentServiceUnitTest
    {
        private readonly ServiceCollection _services;
        private readonly ServiceProvider _serviceProvider;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAppointmentService _appointmentService;

        public AppointmentServiceUnitTest()
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
            _appointmentService = _serviceProvider.GetService<IAppointmentService>();
        }

        [TestMethod]
        public void CreateAppointment()
        {
            var mockUser = new Faker<UserEntity>()
             .RuleFor(u => u.Name, (f, u) => f.Name.FirstName())
             .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
             .RuleFor(u => u.Password, (f, u) => f.Internet.Password());
            
             var user = mockUser.Generate();
            user.Role = RoleConstant.Client;
            var createdUser = _userService.Insert(user);

            var mockProvider = new Faker<UserEntity>()
            .RuleFor(u => u.Name, (f, u) => f.Name.FirstName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name))
            .RuleFor(u => u.Password, (f, u) => f.Internet.Password());
            
            var provider = mockProvider.Generate();
            provider.Role = RoleConstant.Provider;
            var createdProvider = _userService.Insert(provider);

            var mockAppointment = new Faker<AppointmentEntity>()
            .RuleFor(u => u.Date, (f, u) => f.Date.Future());

            var appointment = mockAppointment.Generate();
            appointment.ProviderId = createdProvider.Id;
            appointment.UserId = createdUser.Id;

            //var createdAppoitment = _appointmentService.Insert(user);
            //Assert.IsNotNull(createdUser);
            //Assert.AreEqual(user, createdUser);
        }

    }
}
