using DornadzorTestWebApi.DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DornadzorTestWebApi.BLL.Services;
using DornadzorTestWebApi.DAL.Repositores;
using DornadzorTestWebApi.DAL.Repositores.Interfaces;
using DornadzorTestWebApi.DAL.Entity;
using DornadzorTestWebApi.BLL.Services.Interfaces;
using DornadzorTestWebApi.BLL.Models;

namespace DornadzorTestWebApi.API.Extensions
{
    public static class ServiceProviderExtension
    {
        public static void RegisterDornadzorServices(this IServiceCollection services)
        {
            services.AddScoped<IService<UserModel>, UserService>();
        }

        public static void RegisterDornadzorRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<User>, UserRepository>();
        }

        public static void AddConnectionString(this IServiceCollection services)
        {
            services.AddDbContext<DornadzorContext>(
                options =>
                {
                    options.UseSqlServer(
                                @"Host = localhost; Username = mylogin; Password = mypass; Database = mydatabase");
                });


        }
    }
}
