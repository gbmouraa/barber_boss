using BarberBoss.Domain.Entities;
using FluentValidation;

namespace BaberBoss.Application.UseCases.Billings.Update
{
    internal class UpdateBillingValidator : AbstractValidator<Billing>
    {
        public UpdateBillingValidator()
        {
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
