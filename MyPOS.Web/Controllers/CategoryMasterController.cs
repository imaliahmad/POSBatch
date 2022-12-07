using Microsoft.AspNetCore.Mvc;

namespace MyPOS.Web.Controllers
{
    public class CategoryMasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
