using Microsoft.AspNetCore.Mvc;

namespace deliverybook.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(object result = null)
        {
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }
    }
}