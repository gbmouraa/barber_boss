using AutoMapper;
using BarberBoss.Communication.Requests.Billing;
using BarberBoss.Domain.Entities;

namespace BaberBoss.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
        }

        private void RequestToEntity() => CreateMap<CreateBillingRequest, Billing>();
    }
}
