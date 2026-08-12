using BarberBoss.Communication.Responses;

namespace BaberBoss.Application.UseCases.Billings.GetById
{
    public interface IGetBillingByIdUseCase
    {
        Task<BillingResponse> Execute(Guid id);
    }
}
