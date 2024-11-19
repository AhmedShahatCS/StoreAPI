using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.API.Errors;
using Store.Core.Dtos.Identity;
using Store.Core.Entity.Identity;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountsController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {
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
                Token = "this will be token"
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
                Token = "this will be token"

            };
            return Ok(returneduser);

        }
    }
}
