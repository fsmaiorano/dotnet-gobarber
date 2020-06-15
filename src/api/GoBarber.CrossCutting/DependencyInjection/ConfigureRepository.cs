using GoBarber.Data.Context;
using GoBarber.Data.Repository;
using GoBarber.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            serviceCollection.AddScoped(typeof(IAuthenticationRepository), typeof(AuthenticationRepository));

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer("Server=localhost;user=sa;password=Password123;database=gobarber")
            );
        }
    }
}
