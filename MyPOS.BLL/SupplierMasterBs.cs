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
    public interface ISupplierMasterBs
    {
        IEnumerable<SupplierMasterVM> GetAll();
        SupplierMasterVM GetById(int id);
        SupplierMasterVM Insert(SupplierMasterVM obj);
        SupplierMasterVM Update(SupplierMasterVM obj);
        bool Delete(int id);
    }
    public class SupplierMasterBs: ISupplierMasterBs
    {
        private ISupplierMasterDb objDb;
        public SupplierMasterBs(ISupplierMasterDb _objDb)
        {
            objDb = _objDb;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierMasterVM> GetAll()
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
                cfg.CreateMap<SupplierMaster, SupplierMasterVM>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            var objListVM = mapper.Map<IEnumerable<SupplierMaster>, IEnumerable<SupplierMasterVM>>(objList);

            return objListVM;
        }
        public SupplierMasterVM GetById(int id)
        {
            var obj = objDb.GetById(id);

            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SupplierMaster, SupplierMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var objVM = mapper.Map<SupplierMaster, SupplierMasterVM>(obj);


            return objVM;
        }

        public SupplierMasterVM Insert(SupplierMasterVM objVM)
        {
            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SupplierMasterVM, SupplierMaster>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var obj = mapper.Map<SupplierMasterVM, SupplierMaster>(objVM);

            obj = objDb.Insert(obj);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SupplierMaster, SupplierMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            mapper = config.CreateMapper();

            //3. Map
            objVM = mapper.Map<SupplierMaster, SupplierMasterVM>(obj);
            return objVM;
        }

        public SupplierMasterVM Update(SupplierMasterVM objVM)
        {
            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SupplierMasterVM, SupplierMaster>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var obj = mapper.Map<SupplierMasterVM, SupplierMaster>(objVM);

            obj = objDb.Update(obj);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SupplierMaster, SupplierMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            mapper = config.CreateMapper();

            //3. Map
            objVM = mapper.Map<SupplierMaster, SupplierMasterVM>(obj);
            return objVM;
        }
    }
}
