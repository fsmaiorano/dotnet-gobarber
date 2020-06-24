using AutoMapper;
using GoBarber.Data.UnitOfWork;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.DTO.Appointment;
using GoBarber.DTO.Authentication;
using GoBarber.DTO.User;
using GoBarber.Service.Services.Appointment;
using GoBarber.Service.Services.Authentication;
using GoBarber.Service.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace GoBarber.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IAuthenticationService, AuthenticationService>();
            serviceCollection.AddTransient<IAppointmentService, AppointmentService>();

            //Automapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, UserDTO>();
                cfg.CreateMap<UserInput, UserEntity>();

                cfg.CreateMap<AppointmentEntity, AppointmentDTO>();
                cfg.CreateMap<AppointmentInput, AppointmentEntity>();
            });

            IMapper mapper = config.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}
