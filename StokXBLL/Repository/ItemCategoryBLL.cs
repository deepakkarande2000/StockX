using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using StockXBEntity;
using StokcXDAL;

namespace StokXBLL
{
    public class ItemCategoryBLL:IRepository<ItemCategoryEntity,ItemCategoryEntity>
    {
        SqlDBContext _sqlDBContext=new SqlDBContext();
        public ItemCategoryBLL()
        {            
            
        }

        public async Task<List<ItemCategoryEntity>> AddData(ItemCategoryEntity entity)
        {
            _sqlDBContext.ItemsCategory.AddOrUpdate(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.ItemsCategory.ToList();

        }

        public async Task<List<ItemCategoryEntity>> Delete(ItemCategoryEntity entity)
        {
            _sqlDBContext.ItemsCategory.Remove(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.ItemsCategory.ToList();

        }

        public async Task<List<ItemCategoryEntity>> GetAllItemCategory()
        {
            return _sqlDBContext.ItemsCategory.ToList();
        }

        public async Task<List<ItemCategoryEntity>> Update(ItemCategoryEntity entity)
        {
            _sqlDBContext.ItemsCategory.AddOrUpdate(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.ItemsCategory.ToList();
        }
    }
}
