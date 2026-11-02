using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MerchantRepository(CatalogDbContext _dbContext) : IMerchantRepository
    {
        public Task<List<Merchant>> GetAll() => _dbContext.Merchants.AsNoTracking().ToListAsync();

        public async Task<Merchant?> GetById(Guid id) => await _dbContext.Merchants.FindAsync(id);

        public Task<Merchant?> GetByIdWithCatalogsAndItems(Guid id) =>
            _dbContext.Merchants
                .Include(m => m.Catalogs)
                .ThenInclude(c => c.Items)
                .FirstOrDefaultAsync(m => m.Id == id);

        public Task<bool> Exists(Guid id) => _dbContext.Merchants.AnyAsync(m => m.Id == id);

        public void Add(Merchant merchant) => _dbContext.Merchants.Add(merchant);

        public Task SaveChanges() => _dbContext.SaveChangesAsync();
    }
}
