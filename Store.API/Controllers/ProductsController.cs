using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Errors;
using Store.Core.Dtos.Product;
using Store.Core.Servise.Contract.Products;
using Store.Core.Specifications;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISeviceProduct _seviceProduct;

        public ProductsController(ISeviceProduct seviceProduct) {
            _seviceProduct = seviceProduct;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllProduct(string? sort , int? Brandid , int? Typeid)
        {
           
            var result = await _seviceProduct.GetAllProductAsync(sort, Brandid, Typeid);
            return Ok(result);
        
        
        }
        [HttpGet("brands")]
        public async Task<ActionResult> GeyttAllBrands()
        {
            var result = await _seviceProduct.GetAllBrandAsync();
            return Ok(result);


        }

        [HttpGet("types")]
        public async Task<ActionResult> GeyttAllTypes()
        {
            var result = await _seviceProduct.GetAllTypeAsync();
            return Ok(result);


        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]

        public async Task<ActionResult> GeyttProductById(int?id)
        {
            var result = await _seviceProduct.GetProductById(id);
            if (result is null) return NotFound(new ApiResponse(404));
            return Ok(result);


        }
    }
}
