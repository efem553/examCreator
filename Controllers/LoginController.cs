using examCreator.Models;
using examCreator.Models.Repository;
using examCreator.Models.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace examCreator.Controllers
{
    public class LoginController : Controller
    {
        private IApplicationUserRepository _userRepo;
        public LoginController(IApplicationUserRepository userRepo)
        {
            _userRepo=userRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ApplicationUser _user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userRepo.FirstOrDefault(x => x.UserName == _user.UserName);
                    if (user == null || user.Password!=_user.Password)
                    {
                        TempData["LoginErrorMessage"] = "Kullanıcı Adı/Şifre Hatalı";
                    }
                    else
                    {
                        Guid g = Guid.NewGuid();
                        string guidString = Convert.ToBase64String(g.ToByteArray());
                        guidString = guidString.Replace("=", "");
                        guidString = guidString.Replace("+", "");
                        user.LoggedInSecret = guidString;
                        _userRepo.Update(user);
                        _userRepo.Save();
                        HttpContext.Session.SetString("UserName", user.UserName);
                        HttpContext.Session.SetString("LoggedInSecret", user.LoggedInSecret);
                        return RedirectToAction("Index", "Exam");
                    }
                    return View(user);
                   
                }
                else
                    return View(_user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
