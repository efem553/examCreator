using Microsoft.AspNetCore.Mvc;

namespace examCreator.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
