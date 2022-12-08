using MyPOS.BOL;
using MyPOS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPOS.DAL
{
    public interface IImageMasterDb //dependency injection --> run time polymorphism
    {
        //declaration
        IEnumerable<ImageMaster> GetAll();
        ImageMaster GetById(int id);
        ImageMaster Insert(ImageMaster obj);
        ImageMaster Update(ImageMaster obj);
        bool Delete(int id);
    }
    public class ImageMasterDb : IImageMasterDb
    {
        private EFCoreDbContext context;
        public ImageMasterDb(EFCoreDbContext _context)
        {
            context = _context;
        }
        public bool Delete(int id)
        {
            var obj = context.ImageMaster.Find(id);
            context.ImageMaster.Remove(obj);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<ImageMaster> GetAll()
        {
            return context.ImageMaster;
        }

        public ImageMaster GetById(int id)
        {
            var obj = context.ImageMaster.Find(id);
            return obj;
        }

        public ImageMaster Insert(ImageMaster obj)
        {
            context.ImageMaster.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public ImageMaster Update(ImageMaster obj)
        {
            context.ImageMaster.Update(obj);
            context.SaveChanges();
            return obj;
        }
    }
}
