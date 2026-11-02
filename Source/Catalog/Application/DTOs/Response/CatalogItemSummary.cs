namespace Application.DTOs.Response
{
    public record CatalogItemSummary(Guid Id, Guid CatalogId, string Name, decimal Price, bool IsActive);
}
