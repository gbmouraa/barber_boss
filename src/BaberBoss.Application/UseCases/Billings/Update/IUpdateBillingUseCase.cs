using BarberBoss.Communication.Requests.Billing;

namespace BaberBoss.Application.UseCases.Billings.Update
{
    public interface IUpdateBillingUseCase
    {
        Task Execute(Guid id, UpdateBillingRequest request);
    }
}
