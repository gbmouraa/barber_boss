using AutoMapper;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories.Billing;

namespace BaberBoss.Application.UseCases.Billings.GetById
{
    public class GetBillingByIdUseCase : IGetBillingByIdUseCase
    {
        private readonly IBillingRepository _repository;
        private readonly IMapper _mapper;

        public GetBillingByIdUseCase(IBillingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BillingResponse> Execute(Guid id)
        {
            var result = await _repository.GetById(id);

            if (result is null) { } // criar NotFoundEx

            return _mapper.Map<BillingResponse>(result);
        }
    }
}
