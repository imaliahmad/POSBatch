using MyPOS.BOL;
using MyPOS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPOS.DAL
{
    public interface IProductMasterDb //dependency injection --> run time polymorphism
    {
        //declaration
        IEnumerable<ProductMaster> GetAll();
        ProductMaster GetById(int id);
        ProductMaster Insert(ProductMaster obj);
        ProductMaster Update(ProductMaster obj);
        bool Delete(int id);
    }
    public class ProductMasterDb: IProductMasterDb
    {
        private EFCoreDbContext context;
        public ProductMasterDb(EFCoreDbContext _context)
        {
            context = _context;
        }

        public bool Delete(int id)
        {
            var obj = context.ProductMaster.Find(id);
            context.ProductMaster.Remove(obj);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<ProductMaster> GetAll()
        {
            return context.ProductMaster;
        }

        public ProductMaster GetById(int id)
        {
            var obj = context.ProductMaster.Find(id);
            return obj;
        }

        public ProductMaster Insert(ProductMaster obj)
        {
            context.ProductMaster.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public ProductMaster Update(ProductMaster obj)
        {
            context.ProductMaster.Update(obj);
            context.SaveChanges();
            return obj;
        }
    }
}
