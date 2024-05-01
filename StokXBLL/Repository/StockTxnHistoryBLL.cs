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
   public class StockTxnHistoryBLL: IRepository<StockTxnHistoryEntity, StockTxnHistoryEntity>
    {
        SqlDBContext sqlDBContext = new SqlDBContext();
        SqlDbHelper sqlDbHelper = new SqlDbHelper();
        public async Task<List<StockTxnHistoryEntity>> Update(StockTxnHistoryEntity entity)
        {
            sqlDBContext.tblStockTxnHistory.AddOrUpdate(entity);
            sqlDBContext.SaveChanges();
            return await GetAllStockTransaction();
        }


        public async Task<List<StockTxnHistoryEntity>> AddData(StockTxnHistoryEntity entity)
        {
            sqlDBContext.tblStockTxnHistory.AddOrUpdate(entity);
            sqlDBContext.SaveChanges();
            return await GetAllStockTransaction();
        }

        private async Task<List<StockTxnHistoryEntity>> GetAllStockTransaction()
        {
            return sqlDBContext.tblStockTxnHistory.ToList();
        }

        public async Task<List<StockTxnHistoryEntity>> Delete(StockTxnHistoryEntity entity)
        {
            sqlDBContext.tblStockTxnHistory.Remove(entity);
            sqlDBContext.SaveChanges();
            return await GetAllStockTransaction();
        }

        public async Task<DataSet> GetStockHistoryStmt(string FromDate ,string Todate)
        {
           return sqlDbHelper.FunExecuteDataSet("GetStockForStmt", FromDate, Todate);
        }
    }
}
