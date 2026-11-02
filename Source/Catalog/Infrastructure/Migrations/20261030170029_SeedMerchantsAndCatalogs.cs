using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMerchantsAndCatalogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "Id", "CreationDate", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Zalando" },
                    { new Guid("a0000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Boozt" }
                });

            migrationBuilder.InsertData(
                table: "Catalogs",
                columns: new[] { "Id", "CreationDate", "IsActive", "MerchantId", "Name" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a0000000-0000-0000-0000-000000000001"), "Clothes" },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a0000000-0000-0000-0000-000000000001"), "Shoes" },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a0000000-0000-0000-0000-000000000002"), "Children Clothes" },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("a0000000-0000-0000-0000-000000000002"), "Shoes" }
                });

            migrationBuilder.InsertData(
                table: "CatalogItems",
                columns: new[] { "Id", "CatalogId", "CreationDate", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000001"), new Guid("b0000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Levi's 501 Original Jeans", 1099m },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), new Guid("b0000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Nike Sportswear Club Hoodie", 799m },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), new Guid("b0000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Tommy Hilfiger Oxford Shirt", 899m },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Adidas Stan Smith", 1199m },
                    { new Guid("c0000000-0000-0000-0000-000000000005"), new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Dr. Martens 1460 Boots", 2199m },
                    { new Guid("c0000000-0000-0000-0000-000000000006"), new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Converse Chuck Taylor All Star", 749m },
                    { new Guid("c0000000-0000-0000-0000-000000000007"), new Guid("b0000000-0000-0000-0000-000000000003"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Name It Organic T-shirt", 149m },
                    { new Guid("c0000000-0000-0000-0000-000000000008"), new Guid("b0000000-0000-0000-0000-000000000003"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Molo Jersey Dress", 599m },
                    { new Guid("c0000000-0000-0000-0000-000000000009"), new Guid("b0000000-0000-0000-0000-000000000003"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Reima Winter Jacket", 1299m },
                    { new Guid("c0000000-0000-0000-0000-000000000010"), new Guid("b0000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Kavat Leather Boots", 999m },
                    { new Guid("c0000000-0000-0000-0000-000000000011"), new Guid("b0000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Ecco Biom Sneakers", 1399m },
                    { new Guid("c0000000-0000-0000-0000-000000000012"), new Guid("b0000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, "Viking Rain Boots", 499m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Catalogs",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Catalogs",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Catalogs",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Catalogs",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"));
        }
    }
}
