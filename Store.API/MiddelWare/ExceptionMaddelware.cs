using Store.API.Errors;
using System.Net;
using System.Text.Json;

namespace Store.API.MiddelWare
{
    public class ExceptionMaddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMaddelware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMaddelware(RequestDelegate next,ILogger<ExceptionMaddelware> logger,IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        //InvokeAsync
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                //if (_env.IsDevelopment())
                //{
                //    var Response = new ApiExceptionResponse(500, ex.Message, ex.StackTrace.ToString());
                //}
                //else
                //{
                //    var Response = new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);
                //}
                var Response = _env.IsDevelopment() ? new ApiExceptionResponse(500, ex.Message, ex.StackTrace.ToString()) : new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var JsonResponse = JsonSerializer.Serialize(Response, options);
                context.Response.WriteAsync(JsonResponse);

            }
        }
    }
}
