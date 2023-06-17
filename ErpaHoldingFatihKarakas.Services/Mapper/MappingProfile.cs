using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Baskets.Dto;
using ErpaHoldingFatihKarakas.Domain.Brands;
using ErpaHoldingFatihKarakas.Domain.Brands.Dto;
using ErpaHoldingFatihKarakas.Domain.Categories;
using ErpaHoldingFatihKarakas.Domain.Categories.Dto;
using ErpaHoldingFatihKarakas.Domain.Models;
using ErpaHoldingFatihKarakas.Domain.Models.Dto;
using ErpaHoldingFatihKarakas.Domain.Orders;
using ErpaHoldingFatihKarakas.Domain.Orders.Dto;
using ErpaHoldingFatihKarakas.Domain.Products;
using ErpaHoldingFatihKarakas.Domain.Products.Dto;

namespace ErpaHoldingFatihKarakas.Application.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Brand, BrandCreateDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, BrandUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Model, ModelCreateDto>().ReverseMap();
            CreateMap<Model, ModelUpdateDto>().ReverseMap();
            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<Basket, BasketDto>().ReverseMap();
            CreateMap<Basket, BasketCreateDto>().ReverseMap();
            CreateMap<Basket, BasketUpdateDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<Order, OrderUpdateDto>().ReverseMap();

        }
    }
}
