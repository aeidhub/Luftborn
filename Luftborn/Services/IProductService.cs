using Luftborn.Models;

namespace Luftborn.Services
{
    public interface IProductService
    {
        Task<ResponseModel> GetAllProductsAsync();
    }
}
