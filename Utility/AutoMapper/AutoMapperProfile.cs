using AutoMapper;
using DataTransferObject;
using Entities;

namespace Utility.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
