using BarberBoss.Communication.Requests.Billing;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Billing;

namespace BaberBoss.Application.UseCases.Billings.Create
{
    public class CreateBillingUseCase : ICreateBillingUseCase
    {
        private readonly IBillingRepository _repository;

        public CreateBillingUseCase(IBillingRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(CreateBillingRequest request)
        {
            Billing billing = new Billing
            {
                Id = new Guid(),
                Date = request.Date,
                BarberName = request.BarberName,
                ClientName = request.ClientName,
                ServiceName = request.ServiceName,
                Amount = request.Amount,
                PaymentMethod = (BarberBoss.Domain.Enums.PaymentMethodEnum)request.PaymentMethod,
                Status = (BarberBoss.Domain.Enums.BillingStatusEnum)request.Status,
                CreatedAt = DateTime.Now
            };

            await _repository.Create(billing);
        }
    }
}
