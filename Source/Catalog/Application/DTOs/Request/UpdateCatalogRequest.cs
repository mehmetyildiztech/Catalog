using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request
{
    public record UpdateCatalogRequest([Required] string Name, bool IsActive);
}
