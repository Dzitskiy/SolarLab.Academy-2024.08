using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using SolarLab.Academy.DataAccess;

namespace SolarLab.Academy.Api.Tests
{
    /// <summary>
    /// Тестируемое API приложение (выполнется в памяти).
    /// </summary>
    public class TestWebApplication : WebApplicationFactory<Program>
    {
        public const string AdvertInMemoryDbName = "advert";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Подмена Redis
                var redisDescriptor = services.First(x => x.ServiceType == typeof(IDistributedCache));
                services.Remove(redisDescriptor);
                services.AddSingleton<IDistributedCache, MemoryDistributedCache>();

                // NOTE оставлено для примера
                // var repoDescriptor = services.First(x => x.ServiceType == typeof(IAdvertRepository));
                // services.Remove(repoDescriptor);
                // services.AddScoped<IAdvertRepository, AdvertRepositoryStub>();

                // Подмена DbContext и конфигурации DbContext
                var dbContextOptionsDescriptor = services.First(x => x.ServiceType == typeof(DbContextOptions<AcademyDbContext>));
                services.Remove(dbContextOptionsDescriptor);

                var dbContextDescriptor = services.First(x => x.ServiceType == typeof(AcademyDbContext));
                services.Remove(dbContextDescriptor);

                // Добавление AcademyDbContext, работающего с InMemoryDatabase
                services.AddDbContext<AcademyDbContext>(ConfigureInMemoryDatabaseDbContext);

                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var serviceProvider = scope.ServiceProvider;
                var dbContext = serviceProvider.GetRequiredService<AcademyDbContext>();

                // Создание структуры БД.
                dbContext.Database.EnsureCreated();

                // Заполнение БД тестовыми данными.
                DataSeedHelper.SeedData(dbContext);
            });

            base.ConfigureWebHost(builder);
        }
        
        public AcademyDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AcademyDbContext>();
            ConfigureInMemoryDatabaseDbContext(optionsBuilder);
            return new AcademyDbContext(optionsBuilder.Options);
        }

        private static void ConfigureInMemoryDatabaseDbContext(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase(AdvertInMemoryDbName);
            options.EnableSensitiveDataLogging();
        }
    }
}