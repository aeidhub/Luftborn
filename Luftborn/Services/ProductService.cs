using Luftborn.Models;
using Luftborn.Repositories;

namespace Luftborn.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _repo;
        //private readonly IMapper _mapper;

        public ProductService(IBaseRepository<Product> repo/*, IMapper mapper*/)
        {
            _repo = repo;
            //_mapper = mapper;
        }

        public async Task<ResponseModel> GetAllProductsAsync()
        {
            var respnse = await _repo.GetAllAsync();
            //var productsDto = _mapper.Map<IEnumerable<ProductModelDto>>(products);
            return respnse;
            
        }
    }
}
