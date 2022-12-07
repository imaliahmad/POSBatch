using Microsoft.AspNetCore.Mvc;
using MyPOS.BLL;
using MyPOS.ViewModels;
using System.Reflection;

namespace MyPOS.Web.Controllers
{
    public class CategoryMasterController : Controller
    {
        private ICategoryMasterBs objCategoryMasterBs;
        public CategoryMasterController(ICategoryMasterBs _objCategoryMasterBs)
        {
            objCategoryMasterBs = _objCategoryMasterBs;
        }
        public IActionResult Index()
        {
            var list = objCategoryMasterBs.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            try
            {
                CategoryMasterVM objVM = new CategoryMasterVM();
                if (id > 0)
                {
                    objVM = objCategoryMasterBs.GetById(id);
                }

                return Json(new JsonResponseVM { IsSuccess = true, Data = objVM });
            }
            catch (System.Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponseVM { IsSuccess = false, Message = msg });
            }
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryMasterVM model)
        {
            try
            {
                if (!ModelState.IsValid) // model validations
                {
                    foreach (var item in ModelState.Values)
                    {
                        ModelState.AddModelError("", item.Errors[0].ErrorMessage.ToString());
                    }
                    return Json(ModelState);
                }

                if (model.CategoryId > 0) //Update
                {
                    var objVM = objCategoryMasterBs.Update(model);
                    return Json(new JsonResponseVM { IsSuccess = true, Data = objVM });
                }
                else //Insert
                {
                    var objVM = objCategoryMasterBs.Insert(model);
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
