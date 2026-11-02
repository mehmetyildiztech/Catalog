using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request
{
    public record UpdateMerchantRequest(Guid Id, [Required] string Name, bool IsActive);
}
