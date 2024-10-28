namespace Store.API.Errors
{
    public class ApiExceptionResponse:ApiResponse
    {

        public string? Details { get; set; }

        public ApiExceptionResponse(int statusecode, string? message=null,string? details=null):base(statusecode, message)
        {
            Details = details;
        }
    }
}
