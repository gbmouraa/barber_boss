using BarberBoss.Domain.Enums;

namespace BarberBoss.Domain.Entities
{
    public class Billing
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public string BarberName { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public BillingStatusEnum Status { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
