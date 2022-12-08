using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyPOS.BLL
{
    public class ObjectStorageHelper
    {
        public async static Task<bool> PutObject(string basePath, string filePath, IFormFile file) //Save 
        {
           bool imageUpload = false;       
           string fullPath = Path.Combine(basePath, filePath);

        // C://ObjectStorage/2/1/IM/Files/18-02-51-5:2:12_imgName.png

        string folder = Path.GetDirectoryName(fullPath);

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        if (File.Exists(filePath) == false)
        {
            //save image in local driver
            using (FileStream outputFileStream = new FileStream(fullPath, FileMode.Create))
            {
                var fileBytes = ConvertToBytes(file);
                await outputFileStream.WriteAsync(fileBytes, 0, fileBytes.Length);
                imageUpload = true;
            }
        }
        return imageUpload;

    }
        private static byte[] ConvertToBytes(IFormFile file)
    {
        byte[] bytes = null;
        //Then, Read stream in Binary
        BinaryReader reader = new BinaryReader(file.OpenReadStream());
        bytes = reader.ReadBytes((int)file.Length);
        return bytes;
    }
        public static async Task<ObjectStorageModel> GetObject(string filePath,string basePath)
      {
        ObjectStorageModel obj = new ObjectStorageModel();      
        string fullPath = Path.Combine(basePath, filePath);

        if (File.Exists(fullPath))
        {
            //Read file to byte array
            FileStream stream = System.IO.File.OpenRead(fullPath);
            obj.fileBytes = new byte[stream.Length];

            await stream.ReadAsync(obj.fileBytes, 0, obj.fileBytes.Length);
            stream.Close();
            var info = new System.IO.FileInfo(fullPath);
            if (info != null)
            {
                obj.fileSize = (info.Length / 1000000);//convert bytes to mb , 1024 for kb
            }

        }
        return obj;
    }
        public class ObjectStorageModel
    {
        public byte[] fileBytes { get; set; }
        public long fileSize { get; set; }
    }
    }
}
