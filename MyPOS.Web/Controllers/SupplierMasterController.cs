using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPOS.BOL;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace MyPOS.Web.Controllers
{
    public class SupplierMasterController : Controller
    {
        public SupplierMasterController() //image/pdf --> C:
        {

        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
