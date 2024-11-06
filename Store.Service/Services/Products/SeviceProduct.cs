using AutoMapper;
using Store.Core;
using Store.Core.Dtos.Product;
using Store.Core.Servise.Contract.Products;
using Store.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Specifications;

namespace Store.Service.Services.Products
{
    public class SeviceProduct : ISeviceProduct
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SeviceProduct(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<TypeBrandDto>> GetAllBrandAsync()
        {

            var brand = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();
            var mapped = _mapper.Map<IReadOnlyList<TypeBrandDto>>(brand);
            return mapped;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProductAsync(string? sort, int? Brandid, int? Typeid)
        {
            var spec = new ProductSpecification(sort,Brandid,Typeid);
            var product =await _unitOfWork.Repository<Product, int>().GetAllwithspecAsync(spec);
            var mapped=_mapper.Map<IReadOnlyList<ProductDto>>(product);
            return mapped;
        }

        public async Task<IReadOnlyList<TypeBrandDto>> GetAllTypeAsync()
        {
            var type =await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            var mapped = _mapper.Map<IReadOnlyList<TypeBrandDto>>(type);
            return mapped;
        }

        //public async Task<ProductDto> GetProductById(int? id)
        //{
            
        //    return _mapper.Map<ProductDto>(await _unitOfWork.Repository<Product, int>().GetAsync(id.Value));
        //}

        public async Task<ProductDto> GetProductById(int? id)
        {
            //throw new NotImplementedException();
            var spec = new ProductSpecification(id.Value);
            
            var product = await _unitOfWork.Repository<Product, int>().GetWithSpecAsync(spec);
            var mapped = _mapper.Map<ProductDto>(product);
            return mapped;
        }
    }
}
