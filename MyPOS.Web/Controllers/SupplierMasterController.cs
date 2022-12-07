using Microsoft.AspNetCore.Mvc;

namespace MyPOS.Web.Controllers
{
    public class SupplierMasterController : Controller
    {
        public SupplierMasterController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
