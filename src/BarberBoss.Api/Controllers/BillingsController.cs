using BaberBoss.Application.UseCases.Billings.Create;
using BaberBoss.Application.UseCases.Billings.Get;
using BaberBoss.Application.UseCases.Billings.GetById;
using BarberBoss.Communication.Requests.Billing;
using BarberBoss.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessageResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(CreateBillingRequest request, [FromServices] ICreateBillingUseCase useCase)
        {
            await useCase.Execute(request);
            return Ok();
        }

        [HttpGet] // documentar retornos
        public async Task<ActionResult> Get([FromQuery] GetBillingsRequest request, [FromServices] IGetBillingUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }

        [HttpGet] // documentar retornos
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id, [FromServices] IGetBillingByIdUseCase useCase)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }
    }
}
