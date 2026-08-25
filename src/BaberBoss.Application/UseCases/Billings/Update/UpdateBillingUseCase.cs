using AutoMapper;
using BarberBoss.Communication.Requests.Billing;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Billing;
using BarberBoss.Exception;

namespace BaberBoss.Application.UseCases.Billings.Update
{
    public class UpdateBillingUseCase : IUpdateBillingUseCase
    {
        private readonly IBillingRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBillingUseCase(IBillingRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id, UpdateBillingRequest request)
        {
            var billing = await _repository.GetById(id);

            if (billing is null)
                throw new NotFoundException("Nenhuma despesa encontrada para o ID informado.");

            // o mapping está transformando null em 0;
            if (request.Amount is null)
                request.Amount = billing.Amount;

            _mapper.Map(request, billing);

            if (request.Notes == string.Empty)
                billing.Notes = null;

            Validate(billing);

            _repository.Update(billing);
            await _unitOfWork.Commit();
        }

        private void Validate(Billing billing)
        {
            var validator = new UpdateBillingValidator();
            var result = validator.Validate(billing);

            if (!result.IsValid)
            {
                throw new ErrorOnValidationException(result.Errors.Select(error => error.ErrorMessage).ToList());
            }

        }
    }
}
