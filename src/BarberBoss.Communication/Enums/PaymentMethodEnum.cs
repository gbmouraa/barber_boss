using System.ComponentModel;

namespace BarberBoss.Communication.Enums
{
    public enum PaymentMethodEnum
    {
        [Description("Cartão Crédito")]
        CreditCard = 0,
        [Description("Cartão Débito")]
        DebitCard = 1,
        [Description("Pix")]
        Pix = 2,
        [Description("Dinheiro")]
        Cash = 2,
    }
}
