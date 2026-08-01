using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Billing;
using BarberBoss.Infrastructure.DataAccess;
using BarberBoss.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            AddDbContext(service, configuration);
            AddRepositories(service);
        }

        private static void AddRepositories(IServiceCollection service)
        {
            service.AddScoped<IBillingRepository, BillingRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddDbContext(IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 47));

            service.AddDbContext<BarberBossDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }
    }
}
