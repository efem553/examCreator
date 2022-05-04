using examCreator.Models;
using examCreator.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace examCreator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserAuthentication _userAuth;

        public HomeController(ILogger<HomeController> logger,UserAuthentication userAuth)
        {
            _logger = logger;
            _userAuth = userAuth;
        }

        public IActionResult Index()
        {
            NewsFetcher news = new NewsFetcher();
            List<NewsContent> a = news.GetLastFive();
            if (_userAuth.isUserAuthenticated(HttpContext))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}