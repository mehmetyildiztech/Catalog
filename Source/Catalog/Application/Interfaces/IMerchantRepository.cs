using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMerchantRepository
    {
        Task<List<Merchant>> GetAll();
        Task<Merchant?> GetById(Guid id);
        Task<Merchant?> GetByIdWithCatalogsAndItems(Guid id);
        Task<bool> Exists(Guid id);
        void Add(Merchant merchant);
        Task SaveChanges();
    }
}
