using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Requests.Billing
{
    public class GetBillingsRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? BarberName { get; set; }
        public string? ClientName { get; set; }
        public PaymentMethodEnum? PaymentMethod { get; set; }
        public BillingStatusEnum? Status { get; set; }
    }
}
