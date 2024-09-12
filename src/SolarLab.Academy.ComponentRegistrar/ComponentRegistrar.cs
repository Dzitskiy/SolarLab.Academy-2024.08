using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SolarLab.Academy.AppServices.Contexts.Adverts.Builders;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Contexts.Adverts.Services;
using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.AppServices.Contexts.Categories.Services;
using SolarLab.Academy.AppServices.Contexts.User.Repository;
using SolarLab.Academy.AppServices.Contexts.User.Services;
using SolarLab.Academy.ComponentRegistrar.MapProfiles;
using SolarLab.Academy.DataAccess.Repositories;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.ComponentRegistrar
{
    public static class ComponentRegistrar
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAdvertService, AdvertService>();
            
            //FAKE REPO
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddScoped<IAdvertRepository, AdvertRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IAdvertSpecificationBuilder, AdvertSpecificationBuilder>();
            
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<AdvertProfile>();
            });
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}