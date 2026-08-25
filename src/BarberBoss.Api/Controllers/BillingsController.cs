using BaberBoss.Application.UseCases.Billings.Create;
using BaberBoss.Application.UseCases.Billings.Delete;
using BaberBoss.Application.UseCases.Billings.Get;
using BaberBoss.Application.UseCases.Billings.GetById;
using BaberBoss.Application.UseCases.Billings.Update;
using BarberBoss.Communication.Requests.Billing;
using BarberBoss.Communication.Responses;
using BarberBoss.Exception;
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
        public async Task<IActionResult> Create(CreateBillingRequest request, [FromServices] ICreateBillingUseCase useCase)
        {
            await useCase.Execute(request);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(BillingListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessageResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BillingListResponse>> Get([FromQuery] GetBillingsRequest request, [FromServices] IGetBillingUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ErrorMessageResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BillingResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<BillingResponse>> GetById([FromRoute] Guid id, [FromServices] IGetBillingByIdUseCase useCase)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ErrorMessageResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBillingRequest request, [FromServices] IUpdateBillingUseCase useCase)
        {
            await useCase.Execute(id, request);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ErrorMessageResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromQuery] Guid id, [FromServices] IDeleteBillingUseCase useCase)
        {
            await useCase.Execute(id);
            return Ok();
        }
    }
}
