

using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProducts : Profile
    {
        public AutoMapperProducts()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ShoppingCart, ShoppingCartDto>();  
        }
    }
}