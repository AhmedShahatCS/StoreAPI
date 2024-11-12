using Microsoft.AspNetCore.Mvc;
using Store.Core.Mapping.Products;
using Store.Core.Servise.Contract.Products;
using Store.Core;
using Store.Repository;
using Store.Service.Services.Products;
using Store.API.Errors;
using Store.Core.Repository.Contract;
using Store.Repository.Repository;

namespace Store.API.Extentions
{
    public static class ApplicationsServicesExtention
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection Services)
        {
            Services.AddScoped<IBasketRepository, BasketRepository>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<ISeviceProduct, SeviceProduct>();
            Services.AddScoped<ProductPictureUrlResolver>();

            Services.AddAutoMapper(m => m.AddProfile(new ProductProfile()));

            Services.Configure<ApiBehaviorOptions>(Options =>
            {
                Options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                                 .SelectMany(p => p.Value.Errors)
                                                                 .Select(p => p.ErrorMessage).ToArray();

                    var ValidationErrors = new ApiValidationErrorsResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(ValidationErrors);

                };
            });


            return Services;

        }
    }
}
