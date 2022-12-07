using MyPOS.BOL;
using MyPOS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPOS.DAL
{
    public interface ICategoryMasterDb //dependency injection --> run time polymorphism
    {
        //declaration
        IEnumerable<CategoryMaster> GetAll();
        CategoryMaster GetById(int id);
        CategoryMaster Insert(CategoryMaster obj);
        CategoryMaster Update(CategoryMaster obj);
        bool Delete(int id);
    }
    public class CategoryMasterDb: ICategoryMasterDb
    {
        private EFCoreDbContext context;
        public CategoryMasterDb(EFCoreDbContext _context)
        {
            context = _context;
        }

        public bool Delete(int id)
        {
            var obj = context.CategoryMaster.Find(id);
            context.CategoryMaster.Remove(obj);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<CategoryMaster> GetAll()
        {
            return context.CategoryMaster;
        }

        public CategoryMaster GetById(int id)
        {
            var obj = context.CategoryMaster.Find(id);
            return obj;
        }

        public CategoryMaster Insert(CategoryMaster obj)
        {
            context.CategoryMaster.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public CategoryMaster Update(CategoryMaster obj)
        {
            context.CategoryMaster.Update(obj);
            context.SaveChanges();
            return obj;
        }
    }
}
