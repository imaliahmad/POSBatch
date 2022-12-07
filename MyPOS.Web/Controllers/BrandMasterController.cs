using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MyPOS.BLL;
using MyPOS.ViewModels;

namespace MyPOS.Web.Controllers
{
    public class BrandMasterController : Controller
    {
        private IBrandMasterBs objBrandMasterBs;
        public BrandMasterController(IBrandMasterBs _objBrandMasterBs)
        {
            objBrandMasterBs = _objBrandMasterBs;
        }
        public IActionResult Index()
        {
            var list = objBrandMasterBs.GetAll();
            return View(list);
        }


        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            try
            {
                BrandMasterVM objVM = new BrandMasterVM();

                if (id > 0)
                {
                    objVM = objBrandMasterBs.GetById(id);
                }

                return Json(new JsonResponseVM { IsSuccess = true,  Data = objVM });
            }
            catch (System.Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponseVM { IsSuccess = false, Message=msg });
            }
        }

        [HttpPost]
        public IActionResult CreateOrEdit(BrandMasterVM model)
        {
            try
            {               
                if (model.BrandId > 0) //Update
                {
                    var objVM = objBrandMasterBs.Update(model);
                    return Json(new JsonResponseVM { IsSuccess = true, Data = objVM });
                }
                else //Insert
                {
                    var objVM = objBrandMasterBs.Insert(model);
                    return Json(new JsonResponseVM { IsSuccess = true, Data = objVM });
                }
            }
            catch (System.Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponseVM { IsSuccess = false, Message = msg });
            }
        }
    }
}
