using BarberBoss.Communication.Requests.Billing;
using FluentValidation;

namespace BaberBoss.Application.UseCases.Billings
{
    internal class BillingValidator : AbstractValidator<CreateBillingRequest>
    {
        public BillingValidator()
        {
            RuleFor(b => b.Date).NotEmpty().WithMessage("Informe uma data.")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("A data não pode estar no futuro");
            RuleFor(b => b.BarberName).NotEmpty().WithMessage("Informe o nome do barbeiro");
            RuleFor(b => b.ClientName).NotEmpty().WithMessage("Informe o nome do cliente");
            RuleFor(b => b.ServiceName).NotEmpty().WithMessage("Informe o serviço");
            RuleFor(b => b.Amount).NotEmpty().WithMessage("Informe o valor do serviço")
                .GreaterThan(0).WithMessage("O valor deve ser maior que zero.");
            RuleFor(b => b.Status).IsInEnum().WithMessage("Informe um status de pagamento válido.");
            RuleFor(b => b.PaymentMethod).IsInEnum().WithMessage("Informe um meio de pagamento válido.");
        }
    }
}
