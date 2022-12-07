using Microsoft.EntityFrameworkCore;
using MyPOS.BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPOS.DAL.Data
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           // optionsBuilder.UseSqlServer(@"Server=DESKTOP-93BO602\SQLEXPRESS; Database=MyPos;Trusted_Connection=True;");
        }

        public DbSet<BrandMaster> BrandMaster { get; set; }
        public DbSet<CategoryMaster> CategoryMaster { get; set; }
        public DbSet<ProductMaster> ProductMaster { get; set; }
        public DbSet<SupplierMaster> SupplierMaster { get; set; }
    }
}
