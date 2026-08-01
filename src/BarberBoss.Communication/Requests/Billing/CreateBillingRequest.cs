using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Requests.Billing
{
    public class CreateBillingRequest
    {
        public DateOnly Date { get; set; }
        public string BarberName { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public BillingStatusEnum Status { get; set; }
        public string? Notes { get; set; }
    }
}
