using Microsoft.SqlServer.Server;
using StockXBEntity;
using StokcXDAL;
using StokXDAL;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace StokXBLL.Repository
{
   public class ItemMasterBLL:IRepository<ItemMasterEntity,ItemMasterEntity>
    {
        public SqlDBContext _sqlDBContext = new SqlDBContext();
        SqlDbHelper sqlDbHelper=new SqlDbHelper();
        public ItemMasterBLL()
        {
            
        }

        public List<ItemMasterEntity> itemMasterEntities = new List<ItemMasterEntity>();

        public async Task<List<ItemMasterEntity>> AddData(ItemMasterEntity entity)
        {
            _sqlDBContext.ItemMaster.AddOrUpdate(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.ItemMaster.ToList();
        }

        public async Task<List<ItemMasterEntity>> Delete(ItemMasterEntity entity)
        {
            _sqlDBContext.ItemMaster.Remove(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.ItemMaster.ToList();
        }

        public async Task<List<ItemMasterEntity>> Update(ItemMasterEntity entity)
        {
            _sqlDBContext.ItemMaster.Add(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.ItemMaster.ToList();
        }

        public async Task<DataSet> GetAllItems()
        {
            return sqlDbHelper.FunExecuteDataSetWithoutTimeOut(SqlDbHelper.EnDatabaseCategory.COMMON,
                System.Data.CommandType.StoredProcedure, "GetAllItemDetailsWithTax");            
        }

        public async Task<List<ItemMasterEntity>> GetOnlyItemsDetails()
        {
            return _sqlDBContext.ItemMaster.ToList();
        }
        public async Task<string> GetLatestItemID()
        {
            var result=_sqlDBContext.ItemMaster.ToList();

            if(result.Count > 0)
            {
               return (result.Select(c=>c.ID).Max()+1).ToString();
            }
            else
            {
                return "1";
            }
        }
    }
}
