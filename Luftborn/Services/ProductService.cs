using Luftborn.Dtos;
using Luftborn.Models;
using Luftborn.Repositories;

namespace Luftborn.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _repo;
        private readonly IMapper _mapper;

        public ProductService(IBaseRepository<Product> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResponseModel> GetAllProductsAsync()
        {
            var response = new ResponseModel<List<ProductDto>>();
            
            try
            {
                var result = await _repo.GetAllAsync();
                if(result.Success)
                {
                    response.Response = _mapper.Map<List<ProductDto>>(result.Response);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError(ex.Message);
            }
            return response;
            
        }

        public async Task<ResponseModel> CreateProductAsync(CreateProductDto product)
        {
            var response = new ResponseModel();
            try
            {
                var productModel = _mapper.Map<Product>(product);
                response = await _repo.AddAsync(productModel);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> UpdateProductAsync(ProductDto product)
        {
            var response = await _repo.GetByIdAsync(product.Id);
            try
            {
                if (response.Success)
                {
                    var productModel = _mapper.Map<Product>(product);
                    response = await _repo.UpdateAsync(productModel);
                }
                else
                    response.AddError("This Product isn't exist!");
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError(ex.Message);
            }

            return response;
        }

        public async Task<ResponseModel> DeleteProductAsync(int id)
        {
            var response = await _repo.GetByIdAsync(id);
            try
            {
                if (response.Success)
                {
                    var productModel = _mapper.Map<Product>(response.Response);
                    response = await _repo.DeleteAsync(productModel);
                }
                else
                    response.AddError("This Product isn't exist!");
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError(ex.Message);
            }

            return response;
        }
    }
}
