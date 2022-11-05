using Luftborn.Dtos;
using Luftborn.Models;

namespace Luftborn.Services
{
    public interface IProductService
    {
        Task<ResponseModel> GetAllProductsAsync();
        Task<ResponseModel> CreateProductAsync(CreateProductDto product);
        Task<ResponseModel> UpdateProductAsync(UpdateProductDto product);
        Task<ResponseModel> DeleteProductAsync(int id);
    }
}
