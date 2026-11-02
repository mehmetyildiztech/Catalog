namespace Domain.Entities
{
    public class CatalogItem
    {
        public Guid Id { get; set; }
        public Guid CatalogId { get; set; }
        public Catalog? Catalog { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
