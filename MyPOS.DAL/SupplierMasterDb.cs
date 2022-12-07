using MyPOS.BOL;
using MyPOS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPOS.DAL
{
    public interface ISupplierMasterDb //dependency injection --> run time polymorphism
    {
        //declaration
        IEnumerable<SupplierMaster> GetAll();
        SupplierMaster GetById(int id);
        SupplierMaster Insert(SupplierMaster obj);
        SupplierMaster Update(SupplierMaster obj);
        bool Delete(int id);
    }
    public class SupplierMasterDb: ISupplierMasterDb
    {
        private EFCoreDbContext context;
        public SupplierMasterDb(EFCoreDbContext _context)
        {
            context = _context;
        }
        public bool Delete(int id)
        {
            var obj = context.SupplierMaster.Find(id);
            context.SupplierMaster.Remove(obj);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<SupplierMaster> GetAll()
        {
            return context.SupplierMaster;
        }

        public SupplierMaster GetById(int id)
        {
            var obj = context.SupplierMaster.Find(id);
            return obj;
        }

        public SupplierMaster Insert(SupplierMaster obj)
        {
            context.SupplierMaster.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public SupplierMaster Update(SupplierMaster obj)
        {
            context.SupplierMaster.Update(obj);
            context.SaveChanges();
            return obj;
        }
    }
}
