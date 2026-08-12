using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Responses
{
    public class BillingResponse
    {
        public string BarberName { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public BillingStatusEnum Status { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class BillingListResponse
    {
        public List<BillingResponse> Billings { get; set; }
    }
}
