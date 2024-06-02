using ProductService.Domain.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.RepositoryContracts
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(Product newProduct);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
