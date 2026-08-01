namespace BarberBoss.Domain.Repositories.Billing
{
    public interface IBillingRepository
    {
        Task Create(Entities.Billing billing);
    }
}
