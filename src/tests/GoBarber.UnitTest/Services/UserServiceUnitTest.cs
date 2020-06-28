using AutoMapper;
using Bogus;
using GoBarber.Data.Context;
using GoBarber.Data.Repository;
using GoBarber.Data.UnitOfWork;
using GoBarber.Domain.Constants;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.DTO.Appointment;
using GoBarber.DTO.User;
using GoBarber.Service.Services;
using GoBarber.Service.Services.Appointment;
using GoBarber.Service.Services.Authentication;
using GoBarber.Service.Services.User;
using GoBarber.UnitTest.Fakes;
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
        private readonly IMapper _mapper;

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
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, UserDTO>();
                cfg.CreateMap<UserInput, UserEntity>();
                cfg.CreateMap<UserDTO, UserInput>();

                cfg.CreateMap<AppointmentEntity, AppointmentDTO>();
                cfg.CreateMap<AppointmentInput, AppointmentEntity>();
                cfg.CreateMap<AppointmentDTO, AppointmentInput>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);



            _services = services;
            _serviceProvider = services.BuildServiceProvider();

            _userService = _serviceProvider.GetService<IUserService>();
            _authenticationService = _serviceProvider.GetService<IAuthenticationService>();
            _appointmentService = _serviceProvider.GetService<IAppointmentService>();
            _mapper = _serviceProvider.GetService<IMapper>();
        }

        //var builder = WebHost
        //    .CreateDefaultBuilder()
        //    .UseStartup<Startup>();

        //var server = new TestServer(builder);
        //var client = server.CreateClient();

        [TestMethod]
        public void CreateUser()
        {
            var user = FakeUserFactory.CreateUser();

            var createdUser = _userService.Insert(user);
            Assert.IsNotNull(createdUser);
        }

        [TestMethod]
        public void UpdateUser()
        {
            var user = FakeUserFactory.CreateUser();

            var createdUser = _userService.Insert(user);
            Assert.IsTrue(createdUser.Success);

            createdUser.User.Name = $"{createdUser.User.Name}_edited";

            var userInput = _mapper.Map<UserDTO, UserInput>(createdUser.User);

            var updatedUser = _userService.Update(userInput);
            Assert.IsNotNull(updatedUser.User);
        }

        [TestMethod]
        public void DeleteUserByEmail()
        {
            var user = FakeUserFactory.CreateUser();
            user.Role = RoleConstant.Client;

            var createdUser = _userService.Insert(user);
            Assert.IsNotNull(createdUser);

            var result = _userService.Delete(createdUser.User.Id);
            Assert.IsTrue(result.Success);
        }


        [TestMethod]
        public void ListAllUsers()
        {
            var users = _userService.Get();
            Assert.IsNotNull(users);
        }
    }
}
