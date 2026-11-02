using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICatalogItemRepository
    {
        Task<List<CatalogItem>> GetByCatalog(Guid catalogId);
        Task<CatalogItem?> GetById(Guid catalogId, Guid id);
        void Add(CatalogItem item);
        Task SaveChanges();
    }
}
