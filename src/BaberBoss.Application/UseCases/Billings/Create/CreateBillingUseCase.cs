using BarberBoss.Communication.Requests.Billing;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Billing;

namespace BaberBoss.Application.UseCases.Billings.Create
{
    public class CreateBillingUseCase : ICreateBillingUseCase
    {
        private readonly IBillingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBillingUseCase(IBillingRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(CreateBillingRequest request)
        {
            Validate(request);

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
            await _unitOfWork.Commit();
        }

        private void Validate(CreateBillingRequest request)
        {
            var validator = new BillingValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                throw new Exception(string.Join(" ", result.Errors.Select(x => x.ErrorMessage).ToList()));
            }
        }
    }
}
