using BaberBoss.Application.AutoMapper;
using BaberBoss.Application.UseCases.Billings.Create;
using BaberBoss.Application.UseCases.Billings.Get;
using BaberBoss.Application.UseCases.Billings.GetById;
using BaberBoss.Application.UseCases.Billings.Update;
using Microsoft.Extensions.DependencyInjection;

namespace BaberBoss.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddScoped<ICreateBillingUseCase, CreateBillingUseCase>();
            service.AddScoped<IGetBillingUseCase, GetBillingUseCase>();
            service.AddScoped<IGetBillingByIdUseCase, GetBillingByIdUseCase>();
            service.AddScoped<IUpdateBillingUseCase, UpdateBillingUseCase>();

            service.AddAutoMapper(cfg => cfg.AddProfile<AutoMapping>());
        }
    }
}
