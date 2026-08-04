using BaberBoss.Application.UseCases.Billings.Create;
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
    }
}
