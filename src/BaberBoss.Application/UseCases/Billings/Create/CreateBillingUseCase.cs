using AutoMapper;
using BaberBoss.Application.AutoMapper;
using BarberBoss.Communication.Requests.Billing;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Billing;
using BarberBoss.Exception;

namespace BaberBoss.Application.UseCases.Billings.Create
{
    public class CreateBillingUseCase : ICreateBillingUseCase
    {
        private readonly IBillingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBillingUseCase(IBillingRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Execute(CreateBillingRequest request)
        {
            Validate(request);

            var billing = _mapper.Map<Billing>(request);
            billing.CreatedAt = DateTime.Now;

            await _repository.Create(billing);
            await _unitOfWork.Commit();
        }

        private void Validate(CreateBillingRequest request)
        {
            var validator = new BillingValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                throw new ErrorOnValidationException(result.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }
    }
}
