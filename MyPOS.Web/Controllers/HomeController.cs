using Microsoft.AspNetCore.Mvc;

namespace MyPOS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
