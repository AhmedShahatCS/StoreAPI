using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Errors;
using Store.Core.Dtos.Basket;
using Store.Core.Entity;
using Store.Core.Repository.Contract;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepo,IMapper mapper)
        {
            _basketRepo = basketRepo;
            _mapper = mapper;
        }
        [Authorize]

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var Basket = await _basketRepo.GetBasketAsync(id);
            if (Basket is null) return new CustomerBasket(id);
            return Ok(Basket);

        }
        // update or create basket

        [Authorize]

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            var mappedbasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            var createdorupdatebasket = await _basketRepo.UpdateBasketAsync(mappedbasket);
            if (createdorupdatebasket is null) return BadRequest( new ApiResponse(400));
            return Ok(createdorupdatebasket);
        }
        [Authorize]

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string id)
        {
            return await _basketRepo.DeleteBasketAsync(id);
        }
    }
}
