﻿using AutoMapper;
using Store.Core;
using Store.Core.Dtos.Product;
using Store.Core.Servise.Contract.Products;
using Store.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<TypeBrandDto>> GetAllBrandAsync()
        {

            var brand = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<TypeBrandDto>>(brand);
            return mapped;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var product =await _unitOfWork.Repository<Product, int>().GetAllAsync();
            var mapped=_mapper.Map<IEnumerable<ProductDto>>(product);
            return mapped;
        }

        public async Task<IEnumerable<TypeBrandDto>> GetAllTypeAsync()
        {
            var type =await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<TypeBrandDto>>(type);
            return mapped;
        }

        //public async Task<ProductDto> GetProductById(int? id)
        //{
            
        //    return _mapper.Map<ProductDto>(await _unitOfWork.Repository<Product, int>().GetAsync(id.Value));
        //}

        public async Task<ProductDto> GetProductById(int? id)
        {
            //throw new NotImplementedException();
            var product = await _unitOfWork.Repository<Product, int>().GetAsync(id.Value);
            var mapped = _mapper.Map<ProductDto>(product);
            return mapped;
        }
    }
}
