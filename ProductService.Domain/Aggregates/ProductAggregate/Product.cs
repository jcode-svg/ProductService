using ProductService.Domain.Aggregates.ProductAggregate.DTO.Request;
using ProductService.Domain.GenericModels;

namespace ProductService.Domain.Aggregates.ProductAggregate;

public class Product : Entity<Guid>
{
    public Product() : base(Guid.NewGuid())
    {}

    public string Name { get; set; }
    public decimal Price { get; set; }

    public static Product CreateNewProduct(AddNewProductRequest newProduct)
    {
        return new Product
        {
            Name = newProduct.Name,
            Price = newProduct.Price
        };
    }
}
