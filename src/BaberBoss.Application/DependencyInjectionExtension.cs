using BaberBoss.Application.UseCases.Billings.Create;
using Microsoft.Extensions.DependencyInjection;

namespace BaberBoss.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddScoped<ICreateBillingUseCase,CreateBillingUseCase>();
        }
    }
}
