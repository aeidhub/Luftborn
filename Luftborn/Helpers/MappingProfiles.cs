
using Luftborn.Dtos;
using Luftborn.Models;

namespace Luftborn.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ResponseModel<Product>>().ReverseMap();
            CreateMap<Product, ResponseModel<ProductDto>>().ReverseMap();
        }
    }
}
