using StockXBEntity;
using StokcXDAL;
using StokXDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokXBLL.Repository
{
    public class ShopeeDetailsBLL : IRepository<ShopeeDetailEntity, ShopeeDetailEntity>
    {

        SqlDBContext sqlDBContext = new SqlDBContext();
        SqlDbHelper sqlDbHelper = new SqlDbHelper();
        public async Task<List<ShopeeDetailEntity>> AddData(ShopeeDetailEntity entity)
        {
            if (entity.LicenseNo != "")
            {
                sqlDBContext.ShopeeDetails.AddOrUpdate(entity);
            }
            else
            {
                sqlDBContext.ShopeeDetails.Add(entity);
            }            
            sqlDBContext.SaveChanges();
            return sqlDBContext.ShopeeDetails.ToList();
        }

        public async Task<List<ShopeeDetailEntity>> Delete(ShopeeDetailEntity entity)
        {
            sqlDBContext.ShopeeDetails.Remove(entity);
            sqlDBContext.SaveChanges();
            return sqlDBContext.ShopeeDetails.ToList();
        }

        public async Task<List<ShopeeDetailEntity>> Update(ShopeeDetailEntity entity)
        {            
            sqlDBContext.ShopeeDetails.Add(entity);
            sqlDBContext.SaveChanges();
            return sqlDBContext.ShopeeDetails.ToList();
        }


        public async Task<ShopeeDetailEntity> GetShopeeDetails()
        {
            return sqlDBContext.ShopeeDetails.FirstOrDefault();
        }

        public async Task<DataSet> GetShopeeDetailsDataset()
        {
            return sqlDbHelper.FunExecuteDataSet("GetShopeeDetails");
        }
    }

}
