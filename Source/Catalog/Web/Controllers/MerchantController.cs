using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route(Endpoints.Merchants.Base)]
    public class MerchantController(IMerchantService _merchantService) : ControllerBase
    {
        [ProducesResponseType<List<MerchantSummary>>(StatusCodes.Status200OK)]
        [HttpGet]
        public Task<List<MerchantSummary>> GetAll() => _merchantService.GetAll();

        [ProducesResponseType<MerchantSummary>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Endpoints.Merchants.ById)]
        public async Task<ActionResult<MerchantSummary>> GetById(Guid id) =>
            await _merchantService.GetById(id) is { } merchant
              ? merchant
              : NotFound();

        [ProducesResponseType<MerchantSummary>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<MerchantSummary>> CreateMerchant(CreateMerchantRequest request)
        {
            var merchant = await _merchantService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = merchant.Id }, merchant);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut(Endpoints.Merchants.ById)]
        public async Task<IActionResult> UpdateMerchant(Guid id, UpdateMerchantRequest request) =>
            await _merchantService.Update(id, request) ? NoContent() : NotFound();

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost(Endpoints.Merchants.Activate)]
        public async Task<IActionResult> ActivateMerchant(Guid id) =>
            await _merchantService.SetActive(id, true) ? NoContent() : NotFound();

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost(Endpoints.Merchants.Deactivate)]
        public async Task<IActionResult> DeactivateMerchant(Guid id) =>
            await _merchantService.SetActive(id, false) ? NoContent() : NotFound();
    }
}
