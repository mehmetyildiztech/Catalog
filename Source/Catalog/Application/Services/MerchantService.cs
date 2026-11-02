using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class MerchantService(IMerchantRepository _merchantRepository) : IMerchantService
    {
        public async Task<List<MerchantSummary>> GetAll() =>
            (await _merchantRepository.GetAll()).Select(ToSummary).ToList();

        public async Task<MerchantSummary?> GetById(Guid id) =>
            await _merchantRepository.GetById(id) is { } merchant ? ToSummary(merchant) : null;

        public async Task<MerchantSummary> Create(CreateMerchantRequest request)
        {
            var newMerchant = new Merchant
            {
                Id = Guid.CreateVersion7(),
                Name = request.Name,
                IsActive = request.IsActive,
                CreationDate = DateTime.UtcNow
            };
            _merchantRepository.Add(newMerchant);
            await _merchantRepository.SaveChanges();
            return ToSummary(newMerchant);
        }

        public async Task<bool> Update(Guid id, UpdateMerchantRequest request)
        {
            if (await _merchantRepository.GetByIdWithCatalogsAndItems(id) is not { } merchant)
                return false;

            merchant.Name = request.Name;
            merchant.SetActive(request.IsActive);
            await _merchantRepository.SaveChanges();
            return true;
        }

        public async Task<bool> SetActive(Guid id, bool isActive)
        {
            if (await _merchantRepository.GetByIdWithCatalogsAndItems(id) is not { } merchant)
                return false;

            merchant.SetActive(isActive);
            await _merchantRepository.SaveChanges();
            return true;
        }

        private static MerchantSummary ToSummary(Merchant m) => new(m.Id, m.Name, m.IsActive);
    }
}
