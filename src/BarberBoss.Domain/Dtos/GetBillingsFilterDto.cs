using BarberBoss.Domain.Enums;

namespace BarberBoss.Domain.Dtos
{
    public class GetBillingsFilterDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? BarberName { get; set; }
        public string? ClientName { get; set; }
        public PaymentMethodEnum? PaymentMethod { get; set; }
        public BillingStatusEnum? Status { get; set; }
    }
}
