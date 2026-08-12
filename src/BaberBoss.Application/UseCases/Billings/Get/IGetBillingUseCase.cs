using BarberBoss.Communication.Requests.Billing;
using BarberBoss.Communication.Responses;

namespace BaberBoss.Application.UseCases.Billings.Get
{
    public interface IGetBillingUseCase
    {
        Task<BillingListResponse> Execute(GetBillingsRequest request);
    }
}
