namespace Domain.Entities
{
    public class Merchant
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Catalog> Catalogs { get; set; } = [];

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
            if (!isActive)
                Catalogs.ForEach(c => c.SetActive(false));
        }
    }
}
