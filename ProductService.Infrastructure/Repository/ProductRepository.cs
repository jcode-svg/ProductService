using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Aggregates.ProductAggregate;
using ProductService.Domain.RepositoryContracts;
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.Repository;

public class ProductRepository : RepositoryAbstract, IProductRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _applicationDbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _applicationDbContext.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product> GetProductAsync(Guid id)
    {
        return await _applicationDbContext.Products.FindAsync(id);
    }

    public async Task<Product> AddProductAsync(Product newProduct)
    {
        var newRecord = await _applicationDbContext.Products.AddAsync(newProduct);
        return newRecord.Entity;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _applicationDbContext.SaveChangesAsync(new CancellationToken());
    }
}
