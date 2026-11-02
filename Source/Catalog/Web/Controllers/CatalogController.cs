using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route(Endpoints.Catalogs.Base)]
    public class CatalogController(ICatalogService _catalogService) : ControllerBase
    {
        [ProducesResponseType<List<CatalogSummary>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<List<CatalogSummary>>> GetByMerchant(Guid merchantId) =>
            await _catalogService.GetByMerchant(merchantId) is { } catalogs
              ? catalogs
              : NotFound();

        [ProducesResponseType<CatalogSummary>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Endpoints.Catalogs.ById)]
        public async Task<ActionResult<CatalogSummary>> GetById(Guid merchantId, Guid id) =>
            await _catalogService.GetById(merchantId, id) is { } catalog
              ? catalog
              : NotFound();

        [ProducesResponseType<CatalogSummary>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<ActionResult<CatalogSummary>> CreateCatalog(Guid merchantId, CreateCatalogRequest request) =>
            await _catalogService.Create(merchantId, request) is { } catalog
              ? CreatedAtAction(nameof(GetById), new { merchantId, id = catalog.Id }, catalog)
              : NotFound();

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut(Endpoints.Catalogs.ById)]
        public async Task<IActionResult> UpdateCatalog(Guid merchantId, Guid id, UpdateCatalogRequest request) =>
            await _catalogService.Update(merchantId, id, request) ? NoContent() : NotFound();

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost(Endpoints.Catalogs.Activate)]
        public async Task<IActionResult> ActivateCatalog(Guid merchantId, Guid id) =>
            await _catalogService.SetActive(merchantId, id, true) ? NoContent() : NotFound();

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost(Endpoints.Catalogs.Deactivate)]
        public async Task<IActionResult> DeactivateCatalog(Guid merchantId, Guid id) =>
            await _catalogService.SetActive(merchantId, id, false) ? NoContent() : NotFound();
    }
}
