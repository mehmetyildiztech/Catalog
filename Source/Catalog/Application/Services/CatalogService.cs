using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class CatalogService(ICatalogRepository _catalogRepository, IMerchantRepository _merchantRepository) : ICatalogService
    {
        public async Task<List<CatalogSummary>?> GetByMerchant(Guid merchantId)
        {
            if (!await _merchantRepository.Exists(merchantId))
                return null;

            return (await _catalogRepository.GetByMerchant(merchantId)).Select(ToSummary).ToList();
        }

        public async Task<CatalogSummary?> GetById(Guid merchantId, Guid id) =>
            await _catalogRepository.GetById(merchantId, id) is { } catalog ? ToSummary(catalog) : null;

        public async Task<CatalogSummary?> Create(Guid merchantId, CreateCatalogRequest request)
        {
            if (!await _merchantRepository.Exists(merchantId))
                return null;

            var newCatalog = new Catalog
            {
                Id = Guid.CreateVersion7(),
                MerchantId = merchantId,
                Name = request.Name,
                IsActive = request.IsActive,
                CreationDate = DateTime.UtcNow
            };
            _catalogRepository.Add(newCatalog);
            await _catalogRepository.SaveChanges();
            return ToSummary(newCatalog);
        }

        public async Task<bool> Update(Guid merchantId, Guid id, UpdateCatalogRequest request)
        {
            if (await _catalogRepository.GetByIdWithItems(merchantId, id) is not { } catalog)
                return false;

            catalog.Name = request.Name;
            catalog.SetActive(request.IsActive);
            await _catalogRepository.SaveChanges();
            return true;
        }

        public async Task<bool> SetActive(Guid merchantId, Guid id, bool isActive)
        {
            if (await _catalogRepository.GetByIdWithItems(merchantId, id) is not { } catalog)
                return false;

            catalog.SetActive(isActive);
            await _catalogRepository.SaveChanges();
            return true;
        }

        private static CatalogSummary ToSummary(Catalog c) => new(c.Id, c.Name, c.IsActive);
    }
}
