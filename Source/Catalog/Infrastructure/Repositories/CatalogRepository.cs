using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CatalogRepository(CatalogDbContext _dbContext) : ICatalogRepository
    {
        public Task<List<Catalog>> GetByMerchant(Guid merchantId) =>
            _dbContext.Catalogs.AsNoTracking().Where(c => c.MerchantId == merchantId).ToListAsync();

        public Task<Catalog?> GetById(Guid merchantId, Guid id) =>
            _dbContext.Catalogs.FirstOrDefaultAsync(c => c.Id == id && c.MerchantId == merchantId);

        public Task<Catalog?> GetByIdWithItems(Guid merchantId, Guid id) =>
            _dbContext.Catalogs
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == id && c.MerchantId == merchantId);

        public Task<bool> Exists(Guid id) => _dbContext.Catalogs.AnyAsync(c => c.Id == id);

        public void Add(Catalog catalog) => _dbContext.Catalogs.Add(catalog);

        public Task SaveChanges() => _dbContext.SaveChangesAsync();
    }
}
