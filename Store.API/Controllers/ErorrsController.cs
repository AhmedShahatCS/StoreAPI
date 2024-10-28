using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Errors;

namespace Store.API.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErorrsController : ControllerBase
    {
        public IActionResult Errors(int code)
        {
            return NotFound(new ApiResponse(code));
        }
    }
}
