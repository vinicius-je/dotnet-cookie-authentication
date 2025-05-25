using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookieAuthSystem.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : Controller
    {

        [Authorize(Roles = "User")]
        [HttpGet("user")]
        public ActionResult UserController()
        {
            return Ok("Hello User");
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("manager")]
        public ActionResult ManagerController()
        {
            return Ok("Hello Manager");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public ActionResult AdminController()
        {
            return Ok("Hello Admin");
        }
    }
}
