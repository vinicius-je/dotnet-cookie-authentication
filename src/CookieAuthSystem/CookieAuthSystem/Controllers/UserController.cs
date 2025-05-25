using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookieAuthSystem.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {

        [Authorize(Roles = "Manager")]
        [HttpGet("manager")]
        public ActionResult ManagerView()
        {
            return Ok("Hello Managaer");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public ActionResult AdminView()
        {
            return Ok("Hello Admin");
        }
    }
}
