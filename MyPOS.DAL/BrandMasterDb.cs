using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MyPOS.BOL;
using MyPOS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPOS.DAL
{
    public interface IBrandMasterDb //dependency injection --> run time polymorphism
    {
        //declaration
       IEnumerable<BrandMaster>  GetAll();
        BrandMaster GetById(int id);
        BrandMaster Insert(BrandMaster obj);
        BrandMaster Update(BrandMaster obj);
        bool Delete(int id);
    }
    public class BrandMasterDb : IBrandMasterDb
    {
        private EFCoreDbContext context;
        public BrandMasterDb(EFCoreDbContext _context)
        {
            context = _context;
        }
        public bool Delete(int id)
        {
            var obj = context.BrandMaster.Find(id);
            context.BrandMaster.Remove(obj);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<BrandMaster> GetAll()
        {
            return context.BrandMaster;
        }

        public BrandMaster GetById(int id)
        {
            var obj = context.BrandMaster.Find(id);
            return obj;
        }

        public BrandMaster Insert(BrandMaster obj)
        {
            context.BrandMaster.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public BrandMaster Update(BrandMaster obj)
        {
            context.BrandMaster.Update(obj);
            context.SaveChanges();
            return obj;
        }
    }
}
