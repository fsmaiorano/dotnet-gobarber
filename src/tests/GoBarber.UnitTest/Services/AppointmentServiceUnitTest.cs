using AutoMapper;
using GoBarber.Data.Context;
using GoBarber.Data.Repository;
using GoBarber.Data.UnitOfWork;
using GoBarber.Domain.Constants;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.DTO.Appointment;
using GoBarber.DTO.User;
using GoBarber.Service.Services.Appointment;
using GoBarber.Service.Services.Authentication;
using GoBarber.Service.Services.User;
using GoBarber.UnitTest.Fakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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
        }

        [TestMethod]
        public void CreateAppointment()
        {
            var user_1 = FakeUserFactory.CreateUser();
            user_1.Role = RoleConstant.Client;

            var user_2 = FakeUserFactory.CreateUser();
            user_2.Role = RoleConstant.Client;

            var user_3 = FakeUserFactory.CreateUser();
            user_3.Role = RoleConstant.Client;

            var user_4 = FakeUserFactory.CreateUser();
            user_4.Role = RoleConstant.Client;

            var user_5 = FakeUserFactory.CreateUser();
            user_5.Role = RoleConstant.Client;

            var user_6 = FakeUserFactory.CreateUser();
            user_6.Role = RoleConstant.Client;

            var user_7 = FakeUserFactory.CreateUser();
            user_7.Role = RoleConstant.Client;

            var user_8 = FakeUserFactory.CreateUser();
            user_8.Role = RoleConstant.Client;

            var provider = FakeUserFactory.CreateUser();
            provider.Role = RoleConstant.Provider;

            var createdUser_1 = _userService.Insert(user_1);
            var createdUser_2 = _userService.Insert(user_2);
            var createdUser_3 = _userService.Insert(user_3);
            var createdUser_4 = _userService.Insert(user_4);
            var createdUser_5 = _userService.Insert(user_5);
            var createdUser_6 = _userService.Insert(user_6);
            var createdUser_7 = _userService.Insert(user_7);
            var createdUser_8 = _userService.Insert(user_8);
            var createdProvider = _userService.Insert(provider);

            var appointment_1 = FakeAppointmentFactory.CreateAppointment();
            appointment_1.ProviderId = createdProvider.User.Id;
            appointment_1.UserId = createdUser_1.User.Id;
            var createdAppointment_1 = _appointmentService.Insert(appointment_1);
            Assert.IsNotNull(createdAppointment_1);

            var appointment_2 = FakeAppointmentFactory.CreateAppointment();
            appointment_2.ProviderId = createdProvider.User.Id;
            appointment_2.UserId = createdUser_2.User.Id;
            var createdAppointment_2 = _appointmentService.Insert(appointment_2);
            Assert.IsNotNull(createdAppointment_2);

            var appointment_3 = FakeAppointmentFactory.CreateAppointment();
            appointment_3.ProviderId = createdProvider.User.Id;
            appointment_3.UserId = createdUser_3.User.Id;
            var createdAppointment_3 = _appointmentService.Insert(appointment_3);
            Assert.IsNotNull(createdAppointment_3);

            var appointment_4 = FakeAppointmentFactory.CreateAppointment();
            appointment_4.ProviderId = createdProvider.User.Id;
            appointment_4.UserId = createdUser_4.User.Id;
            var createdAppointment_4 = _appointmentService.Insert(appointment_4);
            Assert.IsNotNull(createdAppointment_4);

            var appointment_5 = FakeAppointmentFactory.CreateAppointment();
            appointment_5.ProviderId = createdProvider.User.Id;
            appointment_5.UserId = createdUser_5.User.Id;
            var createdAppointment_5 = _appointmentService.Insert(appointment_5);
            Assert.IsNotNull(createdAppointment_5);

            var appointment_6 = FakeAppointmentFactory.CreateAppointment();
            appointment_6.ProviderId = createdProvider.User.Id;
            appointment_6.UserId = createdUser_6.User.Id;
            var createdAppointment_6 = _appointmentService.Insert(appointment_6);
            Assert.IsNotNull(createdAppointment_6);

            var appointment_7 = FakeAppointmentFactory.CreateAppointment();
            appointment_7.ProviderId = createdProvider.User.Id;
            appointment_7.UserId = createdUser_7.User.Id;
            var createdAppointment_7 = _appointmentService.Insert(appointment_7);
            Assert.IsNotNull(appointment_7);

            var appointment_8 = FakeAppointmentFactory.CreateAppointment();
            appointment_8.ProviderId = createdProvider.User.Id;
            appointment_8.UserId = createdUser_8.User.Id;
            appointment_8.Date = DateTime.Now;
            var createdAppointment_8 = _appointmentService.Insert(appointment_8);
            Assert.IsNotNull(createdAppointment_8);
        }

        [TestMethod]
        public void GetByDate()
        {
            var user = FakeUserFactory.CreateUser();
            user.Role = RoleConstant.Client;
            var createdUser = _userService.Insert(user);

            var provider = FakeUserFactory.CreateUser();
            provider.Role = RoleConstant.Provider;
            var createdProvider = _userService.Insert(provider);

            var appointment = FakeAppointmentFactory.CreateAppointment();
            appointment.UserId = createdUser.User.Id;
            appointment.ProviderId = createdProvider.User.Id;
            _appointmentService.Insert(appointment);

            var storedAppointments = _appointmentService.GetByProviderId(createdProvider.User.Id);

            var myDate = DateTime.Now;
            var result = storedAppointments.Appointments.Where(x => x.Date.Equals(myDate.Date.ToString("dd-MM-yyyyy"))).ToList();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetByUserId()
        {
            var user = FakeUserFactory.CreateUser();
            user.Role = RoleConstant.Client;
            var createdUser = _userService.Insert(user);

            var provider = FakeUserFactory.CreateUser();
            provider.Role = RoleConstant.Provider;
            var createdProvider = _userService.Insert(provider);

            var appointment = FakeAppointmentFactory.CreateAppointment();
            appointment.UserId = createdUser.User.Id;
            appointment.ProviderId = createdProvider.User.Id;
            _appointmentService.Insert(appointment);

            var storedAppointment = _appointmentService.GetByUserId(createdUser.User.Id);
            Assert.IsNotNull(storedAppointment);
        }

        [TestMethod]
        public void GetByProviderId()
        {
            var user = FakeUserFactory.CreateUser();
            user.Role = RoleConstant.Client;
            var createdUser = _userService.Insert(user);

            var provider = FakeUserFactory.CreateUser();
            provider.Role = RoleConstant.Provider;
            var createdProvider = _userService.Insert(provider);

            var appointment = FakeAppointmentFactory.CreateAppointment();
            appointment.ProviderId = createdUser.User.Id;
            appointment.UserId = createdProvider.User.Id;
            _appointmentService.Insert(appointment);

            var storedAppointment = _appointmentService.GetByProviderId(createdProvider.User.Id);
            Assert.IsNotNull(storedAppointment);
        }

        [TestMethod]
        public void DeleteAppointment()
        {
            var user = FakeUserFactory.CreateUser();
            user.Role = RoleConstant.Client;
            var createdUser = _userService.Insert(user);

            var provider = FakeUserFactory.CreateUser();
            provider.Role = RoleConstant.Provider;
            var createdProvider = _userService.Insert(provider);

            var appointment = FakeAppointmentFactory.CreateAppointment();
            appointment.ProviderId = createdUser.User.Id;
            appointment.UserId = createdProvider.User.Id;

            var createdAppointment = _appointmentService.Insert(appointment);
            Assert.IsNotNull(createdAppointment.Appointment);

            var deletedAppointment = _appointmentService.Delete(createdAppointment.Appointment.Id);
            Assert.IsTrue(deletedAppointment.Success);
        }

        [TestMethod]
        public void UpdateAppointment()
        {
            var user = FakeUserFactory.CreateUser();
            user.Role = RoleConstant.Client;
            var createdUser = _userService.Insert(user);

            var provider = FakeUserFactory.CreateUser();
            provider.Role = RoleConstant.Provider;
            var createdProvider = _userService.Insert(provider);

            var appointment = FakeAppointmentFactory.CreateAppointment();
            appointment.ProviderId = createdUser.User.Id;
            appointment.UserId = createdProvider.User.Id;

            var createdAppointment = _appointmentService.Insert(appointment);
            Assert.IsNotNull(createdAppointment.Appointment);

            var newDate = DateTime.Now;

            createdAppointment.Appointment.Date = newDate;

            var entity = new AppointmentEntity
            {
                ProviderId = createdAppointment.Appointment.ProviderId,
                UserId = createdAppointment.Appointment.UserId,
                Id = createdAppointment.Appointment.Id,
                Date = createdAppointment.Appointment.Date
            };

            var updatedAppointment = _appointmentService.Update(entity);
            Assert.AreEqual(updatedAppointment.Appointment.Date, newDate);
        }
    }
}
