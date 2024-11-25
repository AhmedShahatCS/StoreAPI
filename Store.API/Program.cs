
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using Store.API.Errors;
using Store.API.Extentions;
using Store.API.MiddelWare;
using Store.Core;
using Store.Core.Entity.Identity;
using Store.Core.Mapping.Products;
using Store.Core.Servise.Contract.Products;
using Store.Repository;
using Store.Repository.Data;
using Store.Repository.Data.Contexts;
using Store.Repository.IdentityData;
using Store.Service.Services.Products;

namespace Store.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddSingleton<IConnectionMultiplexer>(options =>
            {
                var connection = builder.Configuration.GetConnectionString("RedisConnection");
                return ConnectionMultiplexer.Connect(connection);
            });

            builder.Services.AddAplicationService();
            builder.Services.AddIdentityService(builder.Configuration);
            var app = builder.Build();

           using var scope= app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var context = service.GetRequiredService<StoreDbContext>();//create obj from storecontext to update database for storeapi db
            var Identitycontext = service.GetRequiredService<AppIdentityDbContext>();//create obj from storecontext to update database for identityapi db
            var usermanger = service.GetRequiredService<UserManager<AppUser>>();
            var loggerfactory =service.GetRequiredService<ILoggerFactory>();
            try
            {
                await context.Database.MigrateAsync();
                await Identitycontext.Database.MigrateAsync();

                await AppIdentityDbContextSeed.SeedUserAsync(usermanger);

                await StoreDbContextSeed.SeedAsync(context);
            }
            catch(Exception ex)
            {
                var logger=loggerfactory.CreateLogger<Program>();
                logger.LogError(ex, "there is problem during apply updata database");
            }


            // Configure the HTTP request pipeline.
            
            if (app.Environment.IsDevelopment())
            {
                app.UseMiddleware<ExceptionMaddelware>();
                app.AddSwaggerMiddleWare();
            }
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseStaticFiles();


            app.MapControllers();

            app.Run();
        }
    }
}
