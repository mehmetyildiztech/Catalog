namespace Domain.Entities
{
    public class Catalog
    {
        public Guid Id { get; set; }
        public Guid MerchantId { get; set; }
        public Merchant? Merchant { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public List<CatalogItem> Items { get; set; } = [];

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
            if (!isActive)
                Items.ForEach(i => i.IsActive = false);
        }
    }
}
