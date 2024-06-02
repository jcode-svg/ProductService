using Microsoft.EntityFrameworkCore;
using ProductService.Application.Contract;
using ProductService.Domain.RepositoryContracts;
using ProductService.Infrastructure.Data;
using ProductService.Infrastructure.Repository;
using ProductApplication = ProductService.Application.Implementation.ProductService;

namespace ProductService.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDb")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductApplication>();
        }
    }
}
