using Microsoft.AspNetCore.Mvc;

namespace TurfBooking.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
