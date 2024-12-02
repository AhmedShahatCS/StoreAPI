using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.API.Errors;
using Store.API.Extentions;
using Store.Core.Dtos.Identity;
using Store.Core.Entity.Identity;
using Store.Core.Servise.Contract;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,ITokenService tokenService,IMapper mapper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("Register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {
            if (CheckEmailIsExist(model.Email).Result.Value)
                return BadRequest(new ApiResponse(400, " this Email Already Used"));
                    
            var User = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                PhoneNumber = model.PhoneNumber,
            };

           var Result=  await _userManager.CreateAsync(User);
            
           if (!Result.Succeeded) return BadRequest(new ApiResponse(400));

            var ReturnedUser = new UserDto()
            {
                DisplayName = User.DisplayName,
                Email = User.Email,
                Token = await _tokenService.CreateTokenAsync(User, _userManager)
            };
            return Ok(ReturnedUser);
            

            


        }


        [HttpPost("Login")]

        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {

            var user=await _userManager.FindByEmailAsync(model.Email);
            if (user is null) return Unauthorized(new ApiResponse(401));

            var result=  await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));
            var returneduser = new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user, _userManager)

            };
            return Ok(returneduser);

        }

        [Authorize]
        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
           var Email= User.FindFirstValue(ClaimTypes.Email);
            var user= await _userManager.FindByEmailAsync(Email);
            var ReturenedUser = new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user, _userManager)
            };

            return Ok(ReturenedUser);

        }

        [Authorize]
        [HttpGet("CurrentAddress")] 
        public async Task<ActionResult<AddressDto>> GetCurrentUserAdderss()
        {
           
            var user=await _userManager.FindUserAddressAsync(User);
            var MappedUser = _mapper.Map<Address, AddressDto>(user.Address);
            return Ok(MappedUser);
        }

        [Authorize]
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDto>> UpdateAddress(AddressDto updatedAddress)
        {
            var user = await _userManager.FindUserAddressAsync(User);
            if (user is null) return Unauthorized(new ApiResponse(401));
            var address = _mapper.Map<AddressDto, Address>(updatedAddress);
            address.Id = user.Address.Id;
            user.Address = address;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return Ok(updatedAddress);
        }

        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>> CheckEmailIsExist(string email)
        {
            //var user= await _userManager.FindByEmailAsync(email);
            //if (user is not null) return false;
            //else return true;

            return await _userManager.FindByEmailAsync(email) is not null;
            

        }
    }
}
