using Microsoft.AspNetCore.Mvc;

namespace MyPOS.Web.Controllers
{
    public class CompanyMasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
