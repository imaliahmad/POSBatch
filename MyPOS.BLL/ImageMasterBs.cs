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
    public interface IImageMasterBs
    {
        IEnumerable<ImageMasterVM> GetAll();
        ImageMasterVM GetById(int id);
        ImageMasterVM Insert(ImageMasterVM obj);
        ImageMasterVM Update(ImageMasterVM obj);
        bool Delete(int id);
    }
    public class ImageMasterBs : IImageMasterBs
    {
        private IImageMasterDb objDb;
        public ImageMasterBs(IImageMasterDb _objDb)
        {
            objDb = _objDb;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImageMasterVM> GetAll()
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
                cfg.CreateMap<ImageMaster, ImageMasterVM>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();

            var objListVM = mapper.Map<IEnumerable<ImageMaster>, IEnumerable<ImageMasterVM>>(objList);

            return objListVM;
        }
        public ImageMasterVM GetById(int id)
        {
            var obj = objDb.GetById(id);

            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImageMaster, ImageMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var objVM = mapper.Map<ImageMaster, ImageMasterVM>(obj);


            return objVM;
        }

        public ImageMasterVM Insert(ImageMasterVM objVM)
        {
            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImageMasterVM, ImageMaster>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var obj = mapper.Map<ImageMasterVM, ImageMaster>(objVM);

            obj = objDb.Insert(obj);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImageMaster, ImageMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            mapper = config.CreateMapper();

            //3. Map
            objVM = mapper.Map<ImageMaster, ImageMasterVM>(obj);
            return objVM;
        }

        public ImageMasterVM Update(ImageMasterVM objVM)
        {
            //1. Create Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImageMasterVM, ImageMaster>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            IMapper mapper = config.CreateMapper();

            //3. Map
            var obj = mapper.Map<ImageMasterVM, ImageMaster>(objVM);

            obj = objDb.Update(obj);

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImageMaster, ImageMasterVM>();
                cfg.IgnoreUnmapped();
            });

            //2. Create IMapper
            mapper = config.CreateMapper();

            //3. Map
            objVM = mapper.Map<ImageMaster, ImageMasterVM>(obj);
            return objVM;
        }
    }
}
