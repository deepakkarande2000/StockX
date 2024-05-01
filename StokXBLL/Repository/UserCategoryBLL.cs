using StockXBEntity;
using System;
using StokcXDAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace StokXBLL.Repository
{
    public class UserCategoryBLL : IRepository<UserCategoryEntity, UserCategoryEntity>
    {
        SqlDBContext _sqlDBContext = new SqlDBContext();
        public async  Task<List<UserCategoryEntity>> AddData(UserCategoryEntity entity)
        {          
                _sqlDBContext.UserCategoryMaster.AddOrUpdate(entity);
                _sqlDBContext.SaveChanges();
                return await GetAllUserCategories();                   
        }

        public async Task<List<UserCategoryEntity>> Delete(UserCategoryEntity entity)
        {
            _sqlDBContext.UserCategoryMaster.Remove(entity);
            _sqlDBContext.SaveChanges();
            return await GetAllUserCategories();
        }

        public async Task<List<UserCategoryEntity>> Update(UserCategoryEntity entity)
        {
            _sqlDBContext.UserCategoryMaster.Add(entity);
            _sqlDBContext.SaveChanges();
            return await GetAllUserCategories();
        }


        public async Task<List<UserCategoryEntity>> GetAllUserCategories()
        {
            return _sqlDBContext.UserCategoryMaster.ToList();
        }
    }
}
