namespace Store.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statuscode, string? message=null)
        {
            StatusCode = statuscode;
            Message = message?? GetDefaultMessageByStatuseCode(statuscode);
        }

        private string? GetDefaultMessageByStatuseCode(int StatusCode)
        {
            return StatusCode switch
            {
                400 => "Bad Request",
                401 => "You Are Not Authorized",
                404 => " Resource NotFound",
                500 => "Internal server Error",
                _ => null
            };
        }

    }
}
