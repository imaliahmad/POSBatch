using AutoMapper;
using MyPOS.BLL.ExtensionMethods;
using MyPOS.BOL;
using MyPOS.DAL;
using MyPOS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPOS.BLL
{
    public interface IBrandMasterBs
    {
        IEnumerable<BrandMasterVM> GetAll();
        BrandMasterVM GetById(int id);
        BrandMasterVM Insert(BrandMasterVM obj);
        BrandMasterVM Update(BrandMasterVM obj);
        bool Delete(int id);
    }
    public class BrandMasterBs : IBrandMasterBs
    {
        private IBrandMasterDb objDb;
        public BrandMasterBs(IBrandMasterDb _objDb)
        {
            objDb = _objDb;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BrandMasterVM> GetAll()
        {
            var objList = objDb.GetAll(); //db.brands.tolist()

            //1. manual mapping
            //2. auto mapping

            //Auto Mapping
            //1. Create configuration
            //2. Create IMapper
            //3. Map

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandMaster, BrandMasterVM>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            var objListVM = mapper.Map<IEnumerable<BrandMaster>, IEnumerable<BrandMasterVM>>(objList);

            return objListVM;
        }
        public BrandMasterVM GetById(int id)
        {
            var obj = objDb.GetById(id);

            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandMaster, BrandMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
           var objVM = mapper.Map<BrandMaster, BrandMasterVM>(obj);


            return objVM;
        }

        public BrandMasterVM Insert(BrandMasterVM objVM)
        {
            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandMasterVM, BrandMaster>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var obj = mapper.Map<BrandMasterVM, BrandMaster>(objVM);

            obj = objDb.Insert(obj);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandMaster, BrandMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            mapper = config.CreateMapper();

            //3. Map
            objVM = mapper.Map<BrandMaster, BrandMasterVM>(obj);
            return objVM;
        }

        public BrandMasterVM Update(BrandMasterVM objVM)
        {
            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandMasterVM, BrandMaster>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var obj = mapper.Map<BrandMasterVM, BrandMaster>(objVM);

            obj = objDb.Update(obj);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandMaster, BrandMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            mapper = config.CreateMapper();

            //3. Map
            objVM = mapper.Map<BrandMaster, BrandMasterVM>(obj);
            return objVM;
        }
    }
}
