using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class CatalogItemService(ICatalogItemRepository _catalogItemRepository, ICatalogRepository _catalogRepository) : ICatalogItemService
    {
        public async Task<List<CatalogItemSummary>?> GetByCatalog(Guid catalogId)
        {
            if (!await _catalogRepository.Exists(catalogId))
                return null;

            return (await _catalogItemRepository.GetByCatalog(catalogId)).Select(ToSummary).ToList();
        }

        public async Task<CatalogItemSummary?> GetById(Guid catalogId, Guid id) =>
            await _catalogItemRepository.GetById(catalogId, id) is { } item ? ToSummary(item) : null;

        public async Task<CatalogItemSummary?> Create(Guid catalogId, CreateCatalogItemRequest request)
        {
            if (!await _catalogRepository.Exists(catalogId))
                return null;

            var newItem = new CatalogItem
            {
                Id = Guid.CreateVersion7(),
                CatalogId = catalogId,
                Name = request.Name,
                Price = request.Price,
                IsActive = request.IsActive,
                CreationDate = DateTime.UtcNow
            };
            _catalogItemRepository.Add(newItem);
            await _catalogItemRepository.SaveChanges();
            return ToSummary(newItem);
        }

        public async Task<bool> Update(Guid catalogId, Guid id, UpdateCatalogItemRequest request)
        {
            if (await _catalogItemRepository.GetById(catalogId, id) is not { } item)
                return false;

            item.Name = request.Name;
            item.Price = request.Price;
            item.IsActive = request.IsActive;
            await _catalogItemRepository.SaveChanges();
            return true;
        }

        public async Task<bool> SetActive(Guid catalogId, Guid id, bool isActive)
        {
            if (await _catalogItemRepository.GetById(catalogId, id) is not { } item)
                return false;

            item.IsActive = isActive;
            await _catalogItemRepository.SaveChanges();
            return true;
        }

        private static CatalogItemSummary ToSummary(CatalogItem i) => new(i.Id, i.CatalogId, i.Name, i.Price, i.IsActive);
    }
}
