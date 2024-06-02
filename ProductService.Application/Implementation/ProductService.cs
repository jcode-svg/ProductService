using ProductService.Application.Contract;
using ProductService.Domain.Aggregates.ProductAggregate;
using ProductService.Domain.Aggregates.ProductAggregate.DTO.Request;
using ProductService.Domain.RepositoryContracts;
using ProductService.SharedKernel;

namespace ProductService.Application.Implementation;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ResponseWrapper<IEnumerable<Product>>> GetAllProducts()
    {
        var products = await _productRepository.GetAllProductsAsync();

        if (products == null || !products.Any())
        {
            return ResponseWrapper<IEnumerable<Product>>.Error("There are no products");
        }

        return ResponseWrapper<IEnumerable<Product>>.Success(products);
    }

    public async Task<ResponseWrapper<Product>> GetProductById(string id)
    {
        var isParsed = Guid.TryParse(id, out Guid parsedId);

        if (!isParsed)
        {
            return ResponseWrapper<Product>.Error("Invalid Product Id");
        }

        var product = await _productRepository.GetProductAsync(parsedId);

        if (product == null)
        {
            return ResponseWrapper<Product>.Error("Invalid Product Id");
        }

        return ResponseWrapper<Product>.Success(product);
    }

    public async Task<ResponseWrapper<string>> AddNewProduct(AddNewProductRequest request)
    {
        var newProduct = Product.CreateNewProduct(request);

        await _productRepository.AddProductAsync(newProduct);
        await _productRepository.SaveChangesAsync();

        return ResponseWrapper<string>.Success("Added Product Successfully");
    }
}
