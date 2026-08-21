using AutoMapper;
using BarberBoss.Communication.Requests.Billing;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Dtos;
using BarberBoss.Domain.Entities;

namespace BaberBoss.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            RequestToDto();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<CreateBillingRequest, Billing>();

            // faz a verificação em cada propiedade de UpdateBillingRequest
            // são mapeadas para a entidade somente as que são diferente de null
            CreateMap<UpdateBillingRequest, Billing>()
                .ForMember(
                    dest => dest.Amount,
                    opt => opt.Condition(src => src.Amount.HasValue)
                )
                .ForAllMembers(
                    opt => opt.Condition((src, dest, srcMember) => srcMember != null)
                );
        }

        private void RequestToDto()
        {
            CreateMap<GetBillingsRequest, GetBillingsFilterDto>();
        }

        private void EntityToResponse()
        {
            CreateMap<Billing, BillingResponse>();
        }
    }
}
