using BarberBoss.Domain.Dtos;

namespace BarberBoss.Domain.Repositories.Billing
{
    public interface IBillingRepository
    {
        Task Create(Entities.Billing billing);
        Task<Entities.Billing> GetById(Guid id);
        Task<List<Entities.Billing>> Get(GetBillingsFilterDto filter);
        void Update(Entities.Billing billing);
    }
}
