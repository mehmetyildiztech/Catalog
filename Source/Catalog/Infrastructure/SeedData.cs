using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class SeedData
    {
        // HasData needs fixed values; generated ids or DateTime.UtcNow would change the model on every migration.
        private static readonly DateTime CreationDate = new(2026, 10, 30, 0, 0, 0, DateTimeKind.Utc);

        private static readonly Guid Zalando = Guid.Parse("a0000000-0000-0000-0000-000000000001");
        private static readonly Guid Boozt = Guid.Parse("a0000000-0000-0000-0000-000000000002");

        private static readonly Guid ZalandoClothes = Guid.Parse("b0000000-0000-0000-0000-000000000001");
        private static readonly Guid ZalandoShoes = Guid.Parse("b0000000-0000-0000-0000-000000000002");
        private static readonly Guid BooztChildrenClothes = Guid.Parse("b0000000-0000-0000-0000-000000000003");
        private static readonly Guid BooztShoes = Guid.Parse("b0000000-0000-0000-0000-000000000004");

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Merchant>().HasData(
                new Merchant { Id = Zalando, Name = "Zalando", IsActive = true, CreationDate = CreationDate },
                new Merchant { Id = Boozt, Name = "Boozt", IsActive = true, CreationDate = CreationDate });

            modelBuilder.Entity<Catalog>().HasData(
                new Catalog { Id = ZalandoClothes, MerchantId = Zalando, Name = "Clothes", IsActive = true, CreationDate = CreationDate },
                new Catalog { Id = ZalandoShoes, MerchantId = Zalando, Name = "Shoes", IsActive = true, CreationDate = CreationDate },
                new Catalog { Id = BooztChildrenClothes, MerchantId = Boozt, Name = "Children Clothes", IsActive = true, CreationDate = CreationDate },
                new Catalog { Id = BooztShoes, MerchantId = Boozt, Name = "Shoes", IsActive = true, CreationDate = CreationDate });

            modelBuilder.Entity<CatalogItem>().HasData(
                Item(1, ZalandoClothes, "Levi's 501 Original Jeans", 1099m),
                Item(2, ZalandoClothes, "Nike Sportswear Club Hoodie", 799m),
                Item(3, ZalandoClothes, "Tommy Hilfiger Oxford Shirt", 899m),
                Item(4, ZalandoShoes, "Adidas Stan Smith", 1199m),
                Item(5, ZalandoShoes, "Dr. Martens 1460 Boots", 2199m),
                Item(6, ZalandoShoes, "Converse Chuck Taylor All Star", 749m),
                Item(7, BooztChildrenClothes, "Name It Organic T-shirt", 149m),
                Item(8, BooztChildrenClothes, "Molo Jersey Dress", 599m),
                Item(9, BooztChildrenClothes, "Reima Winter Jacket", 1299m),
                Item(10, BooztShoes, "Kavat Leather Boots", 999m),
                Item(11, BooztShoes, "Ecco Biom Sneakers", 1399m),
                Item(12, BooztShoes, "Viking Rain Boots", 499m));
        }

        private static CatalogItem Item(int number, Guid catalogId, string name, decimal price) => new()
        {
            Id = Guid.Parse($"c0000000-0000-0000-0000-{number:D12}"),
            CatalogId = catalogId,
            Name = name,
            Price = price,
            IsActive = true,
            CreationDate = CreationDate
        };
    }
}
