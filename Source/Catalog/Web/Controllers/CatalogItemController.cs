using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route(Endpoints.CatalogItems.Base)]
    public class CatalogItemController(ICatalogItemService _catalogItemService) : ControllerBase
    {
        [ProducesResponseType<List<CatalogItemSummary>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<List<CatalogItemSummary>>> GetByCatalog(Guid catalogId) =>
            await _catalogItemService.GetByCatalog(catalogId) is { } items
              ? items
              : NotFound();

        [ProducesResponseType<CatalogItemSummary>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Endpoints.CatalogItems.ById)]
        public async Task<ActionResult<CatalogItemSummary>> GetById(Guid catalogId, Guid id) =>
            await _catalogItemService.GetById(catalogId, id) is { } item
              ? item
              : NotFound();

        [ProducesResponseType<CatalogItemSummary>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<ActionResult<CatalogItemSummary>> CreateCatalogItem(Guid catalogId, CreateCatalogItemRequest request) =>
            await _catalogItemService.Create(catalogId, request) is { } item
              ? CreatedAtAction(nameof(GetById), new { catalogId, id = item.Id }, item)
              : NotFound();

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut(Endpoints.CatalogItems.ById)]
        public async Task<IActionResult> UpdateCatalogItem(Guid catalogId, Guid id, UpdateCatalogItemRequest request) =>
            await _catalogItemService.Update(catalogId, id, request) ? NoContent() : NotFound();

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost(Endpoints.CatalogItems.Activate)]
        public async Task<IActionResult> ActivateCatalogItem(Guid catalogId, Guid id) =>
            await _catalogItemService.SetActive(catalogId, id, true) ? NoContent() : NotFound();

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost(Endpoints.CatalogItems.Deactivate)]
        public async Task<IActionResult> DeactivateCatalogItem(Guid catalogId, Guid id) =>
            await _catalogItemService.SetActive(catalogId, id, false) ? NoContent() : NotFound();
    }
}
