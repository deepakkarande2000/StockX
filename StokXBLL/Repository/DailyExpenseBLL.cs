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
   public class DailyExpenseBLL:IRepository<ExpenseTitleMasterEntity,ExpenseTitleMasterEntity>
    {
        SqlDBContext _sqlDBContext=new SqlDBContext();
        SqlDbHelper _sqlDBHelper = new SqlDbHelper();

        public async Task<List<ExpenseTitleMasterEntity>> AddData(ExpenseTitleMasterEntity entity)
        {
            _sqlDBContext.tblExpenseTitleMaster.AddOrUpdate(entity);
            _sqlDBContext.SaveChanges();
            return await GetAllExpenseTitle();
        }

        public async Task<List<ExpenseTitleMasterEntity>> Delete(ExpenseTitleMasterEntity entity)
        {
            _sqlDBContext.tblExpenseTitleMaster.Remove(entity);
            _sqlDBContext.SaveChanges();
            return await GetAllExpenseTitle();
        }

        public async Task<List<ExpenseTitleMasterEntity>> Update(ExpenseTitleMasterEntity entity)
        {
            _sqlDBContext.tblExpenseTitleMaster.AddOrUpdate(entity);
            _sqlDBContext.SaveChanges();
            return await  GetAllExpenseTitle();
        }

        public async Task<List<ExpenseTitleMasterEntity>> GetAllExpenseTitle()
        {
           return _sqlDBContext.tblExpenseTitleMaster.ToList();
        }

        public async Task<DataSet> GetDailyExpenses(string date)
        {
            return _sqlDBHelper.FunExecuteDataSet("GetDailyExpenses", date);
        }


        public async Task<bool> InsertUpdateDailyExpenses(Int64 ExpenseID,string Date,decimal Amount,
            int paymentMode,string Description,Int64 paidBy,string Payee)
        {
            _sqlDBHelper.FunExecuteNonQuery("InsertUpdateDailyExpenses", ExpenseID, Date, Amount, paymentMode, Description, paidBy,Payee);
            return true;
        }

        public async Task<DataSet>GetDailyExpensesByID(Int64 ID)
        {
           return _sqlDBHelper.FunExecuteDataSet("GetDailyExpensesById", ID);
        }
    }

}
