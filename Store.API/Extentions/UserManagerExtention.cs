using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entity.Identity;

namespace Store.API.Extentions
{
    public static class UserManagerExtention
    {
        public static async Task<AppUser?> FindUserAddressAsync(this UserManager<AppUser> userManager,ClaimsPrincipal User)
        {
            var email=User.FindFirstValue(ClaimTypes.Email);
            var user=await userManager.Users.Include(U=>U.Address).FirstOrDefaultAsync(u=>u.Email== email);

            return user;

        }
    }
}
