using AutoMapper;
using BarberBoss.Communication.Requests.Billing;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Dtos;
using BarberBoss.Domain.Repositories.Billing;

namespace BaberBoss.Application.UseCases.Billings.Get
{
    public class GetBillingUseCase : IGetBillingUseCase
    {
        private readonly IMapper _mapper;
        private readonly IBillingRepository _repository;

        public GetBillingUseCase(IMapper mapper, IBillingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<BillingListResponse> Execute(GetBillingsRequest request)
        {
            var dto = _mapper.Map<GetBillingsFilterDto>(request);
            var result = await _repository.Get(dto);

            return new BillingListResponse
            {              // mapea a lista de billing response a partit do resultado
                Billings = _mapper.Map<List<BillingResponse>>(result)
            };
        }
    }
}
