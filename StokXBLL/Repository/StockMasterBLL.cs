using StockXBEntity;
using StokcXDAL;
using StokXDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokXBLL.Repository
{
    public class StockMasterBLL : IRepository<StockMasterEntity, StockMasterEntity>        
    {
        SqlDBContext sqlDBContext = new SqlDBContext();
        SqlDbHelper sqlDbHelper=new SqlDbHelper();
        public async Task<List<StockMasterEntity>> AddData(StockMasterEntity entity)
        {
            sqlDbHelper.FunExecuteNonQuery("InsertUpdateStock", entity.ItemID, entity.UnitID, entity.Qty,entity.UnitQty);
            return sqlDBContext.tblStockMaster.ToList();
        }

        public async Task<List<StockMasterEntity>> Delete(StockMasterEntity entity)
        {
            sqlDBContext.tblStockMaster.Remove(entity);
            sqlDBContext.SaveChanges();
            return sqlDBContext.tblStockMaster.ToList();
        }

        public async Task<DataSet> GetStockDetails()
        {
            var result = sqlDbHelper.FunExecuteDataSet("GetStockDetails");

            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<StockMasterEntity>> Update(StockMasterEntity entity)
        {
            sqlDBContext.tblStockMaster.AddOrUpdate(entity);
            sqlDBContext.SaveChanges();
            return sqlDBContext.tblStockMaster.ToList();
        }
             

       
    }
}
