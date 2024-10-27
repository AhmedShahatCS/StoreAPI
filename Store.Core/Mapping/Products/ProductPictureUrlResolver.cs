using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Core.Dtos.Product;
using Store.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Mapping.Products
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["ApiBaseUrl"]}{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
