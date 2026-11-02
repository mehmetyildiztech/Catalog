using Application.DTOs.Request;
using Application.DTOs.Response;

namespace Application.Interfaces
{
    public interface ICatalogItemService
    {
        Task<List<CatalogItemSummary>?> GetByCatalog(Guid catalogId);
        Task<CatalogItemSummary?> GetById(Guid catalogId, Guid id);
        Task<CatalogItemSummary?> Create(Guid catalogId, CreateCatalogItemRequest request);
        Task<bool> Update(Guid catalogId, Guid id, UpdateCatalogItemRequest request);
        Task<bool> SetActive(Guid catalogId, Guid id, bool isActive);
    }
}
