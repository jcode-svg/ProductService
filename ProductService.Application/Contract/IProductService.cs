using ProductService.Domain.Aggregates.ProductAggregate;
using ProductService.Domain.Aggregates.ProductAggregate.DTO.Request;
using ProductService.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Contract
{
    public interface IProductService
    {
        Task<ResponseWrapper<string>> AddNewProduct(AddNewProductRequest request);
        Task<ResponseWrapper<IEnumerable<Product>>> GetAllProducts();
        Task<ResponseWrapper<Product>> GetProductById(string id);
    }
}
