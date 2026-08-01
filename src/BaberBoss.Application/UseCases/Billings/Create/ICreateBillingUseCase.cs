using BarberBoss.Communication.Requests.Billing;

namespace BaberBoss.Application.UseCases.Billings.Create
{
    public interface ICreateBillingUseCase
    {
        Task Execute(CreateBillingRequest request);
    }
}
