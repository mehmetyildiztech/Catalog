using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CatalogItemRepository(CatalogDbContext _dbContext) : ICatalogItemRepository
    {
        public Task<List<CatalogItem>> GetByCatalog(Guid catalogId) =>
            _dbContext.CatalogItems.AsNoTracking().Where(i => i.CatalogId == catalogId).ToListAsync();

        public Task<CatalogItem?> GetById(Guid catalogId, Guid id) =>
            _dbContext.CatalogItems.FirstOrDefaultAsync(i => i.Id == id && i.CatalogId == catalogId);

        public void Add(CatalogItem item) => _dbContext.CatalogItems.Add(item);

        public Task SaveChanges() => _dbContext.SaveChangesAsync();
    }
}
