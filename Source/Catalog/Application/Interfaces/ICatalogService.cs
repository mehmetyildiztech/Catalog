using Application.DTOs.Request;
using Application.DTOs.Response;

namespace Application.Interfaces
{
    public interface ICatalogService
    {
        Task<List<CatalogSummary>?> GetByMerchant(Guid merchantId);
        Task<CatalogSummary?> GetById(Guid merchantId, Guid id);
        Task<CatalogSummary?> Create(Guid merchantId, CreateCatalogRequest request);
        Task<bool> Update(Guid merchantId, Guid id, UpdateCatalogRequest request);
        Task<bool> SetActive(Guid merchantId, Guid id, bool isActive);
    }
}
