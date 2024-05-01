using StockXBEntity;
using StockXCore;
using StokcXDAL;
using StokXDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokXBLL
{     
    public class LoginBLL
    {
      public SqlDbHelper _sqlDbHelper;
        SqlDBContext _sqlDbContext;
        public string ConnectionString = "";
        public LoginBLL()
        {
            SqlDbHelper.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(); 
            _sqlDbHelper = SqlDbHelper.Instance();
            _sqlDbContext = new SqlDBContext();
        }

        public bool validateMobileNumber(string username, string mobileno)
        {
            var result = _sqlDbContext.UserMaster.Where(c => c.UserName == username && c.MobileNo == mobileno).FirstOrDefault();

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }           
            
        }

        public DataSet ValidateLoginUser(UserEntity userEntity)
        {
            Func<UserEntity, DataSet> func = (UserEntity) =>
            {
               return _sqlDbHelper.FunExecuteDataSet("ValidateUser", UserEntity.UserName, UserEntity.Password);
            };

            return  func.Invoke(userEntity);
        }

        public async Task<bool> UpdatePassword(string username, string mobilenumber, string tempPassword1)
        {
            var result = _sqlDbContext.UserMaster.Where(c => c.UserName == username && c.MobileNo == mobilenumber).FirstOrDefault();
            if(result!=null)
            {
                UserEntity userentity = new UserEntity()
                {
                    AskToupdatePassword = 1,
                    DesignationId = result.DesignationId,
                    ID = result.ID,
                    IsActive = result.IsActive,
                    MobileNo = result.MobileNo,
                    Password = tempPassword1,
                    UserName = username
                };

                _sqlDbContext.UserMaster.AddOrUpdate(userentity);
                _sqlDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckExpiry()
        {            
            if (GlobalCollection.dsAppSettings != null)
            {
                if (GlobalCollection.dsAppSettings.Tables[0].Rows.Count > 0)
                {
                    var result = GlobalCollection.dsAppSettings.Tables[0].AsEnumerable()
                        .Where(c => c.Field<string>("Col1") == "davli")
                        .Select(c => c.Field<string>("col2")).FirstOrDefault();

                    if (result != null)
                    {
                        if(DateTime.UtcNow.Date < Convert.ToDateTime(result))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<DataSet> GetAppSettings()
        {
            return GlobalCollection.dsAppSettings = _sqlDbHelper.FunExecuteDataSet("GetAllSettings");
        }

        public async Task AddNewUser(UserEntity userEntity)
        {
            _sqlDbContext.UserMaster.Add(userEntity);
           await _sqlDbContext.SaveChangesAsync();
        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await _sqlDbContext.UserMaster.ToListAsync();
        }
    }
}

