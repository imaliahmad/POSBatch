using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyPOS.BLL;
using MyPOS.BOL;
using MyPOS.DAL;
using MyPOS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPOS.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfiguration Configuration;
        public Startup(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddDbContext<EFCoreDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("dbx")));

            #region DAL Services
            services.AddTransient<IBrandMasterDb, BrandMasterDb>();
            services.AddTransient<ICategoryMasterDb, CategoryMasterDb>();
            services.AddTransient<ISupplierMasterDb, SupplierMasterDb>();
            services.AddTransient<IProductMasterDb, ProductMasterDb>();
            #endregion
            #region BLL Services
            services.AddTransient<IBrandMasterBs, BrandMasterBs>();
            services.AddTransient<ICategoryMasterBs, CategoryMasterBs>();
            services.AddTransient<ISupplierMasterBs, SupplierMasterBs>();
            services.AddTransient<IProductMasterBs, ProductMasterBs>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "defualt",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
