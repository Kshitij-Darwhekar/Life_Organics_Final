using Microsoft.AspNetCore.Mvc;
using OrganicStore.Models;

namespace OrganicStore.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            User uModel = new User();
            uModel.username = user.username;
            uModel.email = user.email;
            uModel.password = user.password;
            int res = uModel.SaveUserDetails();
            return RedirectToAction("Index", "Home", user);
        }
    }
}
