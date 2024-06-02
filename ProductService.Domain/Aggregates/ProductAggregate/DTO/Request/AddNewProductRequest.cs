using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain.Aggregates.ProductAggregate.DTO.Request;

public class AddNewProductRequest
{
    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(100, ErrorMessage = "Product name cannot be longer than 100 characters.")]
    public string Name { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public decimal Price { get; set; }
}
