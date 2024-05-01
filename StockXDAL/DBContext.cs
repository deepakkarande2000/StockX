using Microsoft.SqlServer.Server;
using StockXBEntity;
using StokXDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokcXDAL
{
    public sealed class SqlDBContext:DbContext
    {
        SqlDBContext sqldBContext;
        public SqlDBContext():base(SqlDbHelper.ConnectionString)
        {
            
        }
        //SqlDBContext.Database.Connection.ConnectionString= SqlDbHelper.ConnectionString;
        public DbSet<ItemCategoryEntity> ItemsCategory { get; set; }
        public DbSet<TaxCategoryEntity> TaxCategories { get; set; }
        public DbSet<UnitCategoryEntity> UnitCategories { get; set; }
        public DbSet<UserEntity> UserMaster { get; set; }
        public DbSet<ItemMasterEntity> ItemMaster { get; set; }
        //public DbSet<ItemTaxMappingEntity> ItemTaxMapping { get; set; }
        public DbSet<UserCategoryEntity> UserCategoryMaster { get; set; }
        public DbSet<ShopeeDetailEntity> ShopeeDetails { get; set; }
        public DbSet<CustomerMasterEntity> tblCustomerMaster { get; set; }
        public DbSet<SupplierMasterEntity> tblSupplierMaster { get; set; }        
        public DbSet<tblBilling> tblBillDetail { get; set; }        
        public DbSet<BillItemsEntity> tblBillItems { get; set; }        
        public DbSet<BillTaxEntity> tblBillTax { get; set; }        
        public DbSet<BillPaymentEntity> tblBillPayment { get; set; }        
        public DbSet<PaymentModeEntity> tblPaymentMode { get; set; }        
        public DbSet<ItemTaxMappingEntity> tblItemTaxMapping { get; set; }
        public DbSet<StockMasterEntity> tblStockMaster { get; set; }
        public DbSet<tblOutstandingMasterEntity> tblOutstandingMaster { get; set; }
        public DbSet<tblOutstandingTxnEntity> tblOutstandingTransaction { get; set; }
        public DbSet<StockTxnHistoryEntity> tblStockTxnHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemCategoryEntity>().HasKey(x => x.ID);
            modelBuilder.Entity<TaxCategoryEntity>().HasKey(x => x.ID);
            modelBuilder.Entity<UnitCategoryEntity>().HasKey(x => x.UnitID);
            modelBuilder.Entity<UserEntity>().HasKey(x => x.UserName);
            modelBuilder.Entity<ItemMasterEntity>().HasKey(x => x.ID);
            modelBuilder.Entity<ItemTaxMappingEntity>().HasKey(x =>new { x.ItemID, x.TaxID });
            modelBuilder.Entity<ShopeeDetailEntity>().HasKey(x => x.LicenseNo);
            modelBuilder.Entity<SupplierMasterEntity>().HasKey(x => x.ID);
            modelBuilder.Entity<tblBilling>().HasKey(x => x.BillID);
            modelBuilder.Entity<BillItemsEntity>().HasKey(x => x.BillID);
            modelBuilder.Entity<BillTaxEntity>().HasKey(x => x.BillID);
            modelBuilder.Entity<BillPaymentEntity>().HasKey(x => new { x.BillID ,x.PaymentMode});
            modelBuilder.Entity<PaymentModeEntity>().HasKey(x => x.ID);
            modelBuilder.Entity<tblOutstandingMasterEntity>().HasKey(x => x.ID);
            modelBuilder.Entity<tblOutstandingTxnEntity>().HasKey(x => x.ID);
            modelBuilder.Entity<tblOutstandingTxnEntity>().HasKey(x => x.ID);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);            
        }
    }
}
