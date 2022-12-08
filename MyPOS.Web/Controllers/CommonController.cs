
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System;
using MyPOS.BLL;
using MyPOS.ViewModels;
using Microsoft.CodeAnalysis.Operations;

namespace MyPOS.Web.Controllers
{
    public class CommonController : Controller
    {
        private IConfiguration configuration;
        private IImageMasterBs objImageMasterBs;
        private static List<string> ImageExtensions = new List<string>() {".png",".jpg",".jpeg" };
        public CommonController(IConfiguration _configuration, IImageMasterBs _objImageMasterBs)
        {
            configuration = _configuration;
            objImageMasterBs = _objImageMasterBs;
        }
        //uploading, downloading, 
        public async Task<IActionResult> UploadSingleImage()
        {
            // read file, validation
            // save file  -> local drive (C:, D:)
            // save path in database

            try
            {
                var file = Request.Form.Files[0];
                string filePath = "";
                string fullPath = "";  //     F://ObjectStorage/        MyPOS/images/uniqueName
                ObjectVM returnObj = new ObjectVM();

                string fileName = file.FileName; // abc.jpg
                long fileSize = file.Length;

                string extension = Path.GetExtension(fileName);

                bool isImageValid = false;
                if (ImageExtensions.Contains(extension))
                    isImageValid = true;

                
                filePath = "MyPOS/" + (isImageValid ? "Images/" : "Files/") + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss-ff") + "_" + fileName;

                string basePath = configuration["ObjectStoragePath"];
                fullPath = Path.Combine(basePath, fullPath);

                //Locally save
                bool isLocallySaved = await ObjectStorageHelper.PutObject(basePath, filePath, file);
                if (isLocallySaved)
                {
                    //Save in Database
                    ImageMasterVM objImageVM = new ImageMasterVM() { FileName = fileName, FileExtension = extension, FilePath = filePath };
                    objImageVM = objImageMasterBs.Insert(objImageVM);

                    var obj = await ObjectStorageHelper.GetObject(filePath, basePath);
                    if (obj != null && obj.fileBytes != null)
                    {
                        returnObj.ImageId = objImageVM.ImageMasterId;
                        returnObj.FilePathURL = filePath;
                        returnObj.FilePathStr = Convert.ToBase64String(obj.fileBytes);
                    }
                }

                return Json(new JsonResponseVM() { IsSuccess = true, Data = returnObj });

            }
            catch (System.Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponseVM() { IsSuccess = false, Message = msg });
            }

           
        }

    }
}
