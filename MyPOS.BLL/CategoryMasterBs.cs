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
    public interface ICategoryMasterBs
    {
        IEnumerable<CategoryMasterVM> GetAll();
        CategoryMasterVM GetById(int id);
        CategoryMasterVM Insert(CategoryMasterVM obj);
        CategoryMasterVM Update(CategoryMasterVM obj);
        bool Delete(int id);
    }
    public class CategoryMasterBs: ICategoryMasterBs
    {
        private ICategoryMasterDb objDb;
        public CategoryMasterBs(ICategoryMasterDb _objDb)
        {
            objDb = _objDb;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryMasterVM> GetAll()
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
                cfg.CreateMap<CategoryMaster, CategoryMasterVM>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            var objListVM = mapper.Map<IEnumerable<CategoryMaster>, IEnumerable<CategoryMasterVM>>(objList);

            return objListVM;
        }
        public CategoryMasterVM GetById(int id)
        {
            var obj = objDb.GetById(id);

            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryMaster, CategoryMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var objVM = mapper.Map<CategoryMaster, CategoryMasterVM>(obj);


            return objVM;
        }

        public CategoryMasterVM Insert(CategoryMasterVM objVM)
        {
            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryMasterVM, CategoryMaster>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var obj = mapper.Map<CategoryMasterVM, CategoryMaster>(objVM);

            obj = objDb.Insert(obj);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryMaster, CategoryMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            mapper = config.CreateMapper();

            //3. Map
            objVM = mapper.Map<CategoryMaster, CategoryMasterVM>(obj);
            return objVM;
        }

        public CategoryMasterVM Update(CategoryMasterVM objVM)
        {
            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryMasterVM, CategoryMaster>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var obj = mapper.Map<CategoryMasterVM, CategoryMaster>(objVM);

            obj = objDb.Update(obj);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryMaster, CategoryMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            mapper = config.CreateMapper();

            //3. Map
            objVM = mapper.Map<CategoryMaster, CategoryMasterVM>(obj);
            return objVM;
        }
    }
}
