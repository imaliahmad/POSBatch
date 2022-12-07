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
    public interface IProductMasterBs
    {
        IEnumerable<ProductMasterVM> GetAll();
        ProductMasterVM GetById(int id);
        ProductMasterVM Insert(ProductMasterVM obj);
        ProductMasterVM Update(ProductMasterVM obj);
        bool Delete(int id);
    }
    public class ProductMasterBs: IProductMasterBs
    {
        private IProductMasterDb objDb;
        public ProductMasterBs(IProductMasterDb _objDb)
        {
            objDb = _objDb;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductMasterVM> GetAll()
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
                cfg.CreateMap<ProductMaster, ProductMasterVM>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            var objListVM = mapper.Map<IEnumerable<ProductMaster>, IEnumerable<ProductMasterVM>>(objList);

            return objListVM;
        }
        public ProductMasterVM GetById(int id)
        {
            var obj = objDb.GetById(id);

            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductMaster, ProductMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var objVM = mapper.Map<ProductMaster, ProductMasterVM>(obj);


            return objVM;
        }

        public ProductMasterVM Insert(ProductMasterVM objVM)
        {
            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductMasterVM, ProductMaster>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var obj = mapper.Map<ProductMasterVM, ProductMaster>(objVM);

            obj = objDb.Insert(obj);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductMaster, ProductMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            mapper = config.CreateMapper();

            //3. Map
            objVM = mapper.Map<ProductMaster, ProductMasterVM>(obj);
            return objVM;
        }

        public ProductMasterVM Update(ProductMasterVM objVM)
        {
            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductMasterVM, ProductMaster>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var obj = mapper.Map<ProductMasterVM, ProductMaster>(objVM);

            obj = objDb.Update(obj);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductMaster, ProductMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            mapper = config.CreateMapper();

            //3. Map
            objVM = mapper.Map<ProductMaster, ProductMasterVM>(obj);
            return objVM;
        }
    }
}
