using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICatalogRepository
    {
        Task<List<Catalog>> GetByMerchant(Guid merchantId);
        Task<Catalog?> GetById(Guid merchantId, Guid id);
        Task<Catalog?> GetByIdWithItems(Guid merchantId, Guid id);
        Task<bool> Exists(Guid id);
        void Add(Catalog catalog);
        Task SaveChanges();
    }
}
