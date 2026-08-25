using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Billing;
using BarberBoss.Exception;

namespace BaberBoss.Application.UseCases.Billings.Delete
{
    public class DeleteBillingUseCase : IDeleteBillingUseCase
    {
        private readonly IBillingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBillingUseCase(IBillingRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid id)
        {
            var result = await _repository.Delete(id);

            if (!result)
                throw new NotFoundException("Não foi encontrado nenhuma despesa para o ID informado");

            await _unitOfWork.Commit();
        }
    }
}
