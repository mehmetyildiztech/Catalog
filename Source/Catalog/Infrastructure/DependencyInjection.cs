using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
          services.AddDbContext<CatalogDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("Catalog")))
          .AddScoped<IMerchantRepository, MerchantRepository>()
          .AddScoped<ICatalogRepository, CatalogRepository>()
          .AddScoped<ICatalogItemRepository, CatalogItemRepository>();
    }
}
