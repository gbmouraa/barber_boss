using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Billing;

namespace BarberBoss.Infrastructure.DataAccess.Repositories
{
    internal class BillingRepository : IBillingRepository
    {
        private readonly BarberBossDbContext _dbContext;

        public BillingRepository(BarberBossDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Billing billing)
        {
            _dbContext.Billings.Add(billing);
            await _dbContext.SaveChangesAsync();
        }
    }
}
