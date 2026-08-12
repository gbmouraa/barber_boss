using BarberBoss.Domain.Enums;

namespace BarberBoss.Domain.Dtos
{
    public class GetBillingsFilterDto // onde criar a validacao para Page e PageSize no auto mapper
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? BarberName { get; set; }
        public string? ClientName { get; set; }
        public PaymentMethodEnum? PaymentMethod { get; set; }
        public BillingStatusEnum? Status { get; set; }
    }
}
