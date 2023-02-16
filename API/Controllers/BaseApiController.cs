using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //GET /api/users to access this particular controller
    public class BaseApiController : ControllerBase
    {
        
    }
}