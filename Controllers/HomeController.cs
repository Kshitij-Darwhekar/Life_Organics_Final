using Microsoft.AspNetCore.Mvc;
using OrganicStore.Models;
using System.Diagnostics;
using Newtonsoft.Json;

namespace OrganicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contactus()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Products()
        {
            string productsJson = TempData["Products"] as string;
            List<Products> res = JsonConvert.DeserializeObject<List<Products>>(productsJson);

            ViewData["Products"] = res;

            /*List<products> temp = new List<products>();
           
            temp = res;
            Console.WriteLine("1");
            */
            return View(res);
        }
            public IActionResult Cart()
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
