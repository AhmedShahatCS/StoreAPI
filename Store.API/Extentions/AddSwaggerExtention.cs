namespace Store.API.Extentions
{
    public static class AddSwaggerExtention
    {
        public static WebApplication AddSwaggerMiddleWare(this WebApplication app)
        {

            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
