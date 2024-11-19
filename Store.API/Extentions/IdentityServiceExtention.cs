using Microsoft.AspNetCore.Identity;
using Store.Core.Entity.Identity;
using Store.Repository.IdentityData;

namespace Store.API.Extentions
{
    public static class IdentityServiceExtention
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddAuthentication();

            return services;
        }  
    }
}
