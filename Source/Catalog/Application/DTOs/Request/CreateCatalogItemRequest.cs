using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request
{
    public record CreateCatalogItemRequest([Required] string Name, [Range(0.0, double.MaxValue)] decimal Price, bool IsActive);
}
