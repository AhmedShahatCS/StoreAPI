
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.API.Errors;
using Store.API.Extentions;
using Store.API.MiddelWare;
using Store.Core;
using Store.Core.Mapping.Products;
using Store.Core.Servise.Contract.Products;
using Store.Repository;
using Store.Repository.Data;
using Store.Repository.Data.Contexts;
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

            builder.Services.AddAplicationService();
            var app = builder.Build();

           using var scope= app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var context = service.GetRequiredService<StoreDbContext>();
            var loggerfactory=service.GetRequiredService<ILoggerFactory>();
            try
            {
                await context.Database.MigrateAsync();
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

            app.UseAuthorization();
            app.UseStaticFiles();


            app.MapControllers();

            app.Run();
        }
    }
}
