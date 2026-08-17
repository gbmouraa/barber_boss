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

        private void RequestToEntity() => CreateMap<CreateBillingRequest, Billing>();

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
