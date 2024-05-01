using StockXBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StokcXDAL;
using System.Threading.Tasks;

namespace StokXBLL.Repository
{
    public class UserMasterBLL : IRepository<UserEntity, UserEntity>
    {
        SqlDBContext _sqlDBContext=new SqlDBContext();
        public async Task<List<UserEntity>> AddData(UserEntity entity)
        {
            _sqlDBContext.UserMaster.Add(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.UserMaster.ToList();
        }

        public async Task<List<UserEntity>> Delete(UserEntity entity)
        {
            _sqlDBContext.UserMaster.Remove(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.UserMaster.ToList();
        }

        public async Task<List<UserEntity>> Update(UserEntity entity)
        {
            _sqlDBContext.UserMaster.Add(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.UserMaster.ToList();
        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            return _sqlDBContext.UserMaster.ToList();
        }
    }
}
