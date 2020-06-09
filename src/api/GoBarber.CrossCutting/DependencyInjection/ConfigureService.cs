using GoBarber.Domain.Interfaces.Services;
using GoBarber.Service.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace GoBarber.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
        }
    }
}
