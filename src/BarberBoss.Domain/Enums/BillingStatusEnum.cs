using System.ComponentModel;

namespace BarberBoss.Domain.Enums
{
    public enum BillingStatusEnum
    {
        [Description("Pago")]
        Paid = 0,
        [Description("Canceled")]
        Canceled = 1,
    }
}
