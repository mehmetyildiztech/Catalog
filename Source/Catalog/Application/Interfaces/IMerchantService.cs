using Application.DTOs.Request;
using Application.DTOs.Response;

namespace Application.Interfaces
{
    public interface IMerchantService
    {
        Task<List<MerchantSummary>> GetAll();
        Task<MerchantSummary?> GetById(Guid id);
        Task<MerchantSummary> Create(CreateMerchantRequest request);
        Task<bool> Update(Guid id, UpdateMerchantRequest request);
        Task<bool> SetActive(Guid id, bool isActive);
    }
}
