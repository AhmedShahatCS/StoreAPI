using AutoMapper;
using Store.Core.Dtos.Basket;
using Store.Core.Dtos.Identity;
using Store.Core.Dtos.Product;
using Store.Core.Entity;
using Store.Core.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Mapping.Products
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {

            CreateMap<Product, ProductDto>()
                .ForMember(d => d.BrandName, options => options.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.TypeName, options => options.MapFrom(s => s.Type.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());

            CreateMap<ProductType, TypeBrandDto>();
            CreateMap<ProductBrand, TypeBrandDto>();

            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();



        }
    }
}
