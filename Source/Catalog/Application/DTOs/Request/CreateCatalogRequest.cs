using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request
{
    public record CreateCatalogRequest([Required] string Name, bool IsActive);
}
