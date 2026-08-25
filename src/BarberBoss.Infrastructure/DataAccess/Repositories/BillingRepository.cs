using BarberBoss.Domain.Dtos;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Billing;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> Delete(Guid id)
        {
            var billing = await GetById(id);

            if (billing == null)
                return false;

            _dbContext.Billings.Remove(billing);
            return true;
        }

        public async Task<List<Billing>> Get(GetBillingsFilterDto filter)
        {
            // usado para montar a query
            IQueryable<Billing> query = _dbContext.Billings.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filter.BarberName))
                query = query.Where(x => x.BarberName.Contains(filter.BarberName));
            if (!string.IsNullOrWhiteSpace(filter.ClientName))
                query = query.Where(x => x.BarberName.Contains(filter.ClientName));
            if (filter.Status is not null)
                query = query.Where(x => x.Status == filter.Status);
            if (filter.PaymentMethod is not null)
                query = query.Where(x => x.PaymentMethod == filter.PaymentMethod);

            var total = await query.CountAsync();
            var billings = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return billings;
        }

        public async Task<Billing?> GetById(Guid id)
        {
            return await _dbContext.Billings.AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(Billing billing)
        {
            _dbContext.Billings.Update(billing);
        }
    }
}
