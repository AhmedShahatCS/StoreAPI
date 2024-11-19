using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.Core.Entity.Identity;

namespace Store.Repository.IdentityData
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                DisplayName = "Ahmed Shahat",
                Email = "ahmedshahat@gmail.com",
                UserName= "ahmedshahat",
                PhoneNumber="01023123485"

                };
                 await userManager.CreateAsync(user, "Pa$$w0rd");
            }

        }
       
    }
}
