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
    public class OutstandingBLL : IRepository<tblOutstandingMasterEntity, tblOutstandingMasterEntity>
    {
        SqlDbHelper _sqlDbHelper = new SqlDbHelper();
        SqlDBContext _sqlDBContext = new SqlDBContext();
        public async Task<List<tblOutstandingMasterEntity>> AddData(tblOutstandingMasterEntity entity)
        {
            _sqlDBContext.tblOutstandingMaster.AddOrUpdate(entity);
            _sqlDBContext.SaveChanges();
            return await GetOutstanding();
        }
        public async Task<List<tblOutstandingMasterEntity>> Delete(tblOutstandingMasterEntity entity)
        {
            _sqlDBContext.tblOutstandingMaster.Attach(entity);
            _sqlDBContext.tblOutstandingMaster.Remove(entity);
            _sqlDBContext.SaveChanges();
            return await GetOutstanding();
        }
        public async Task<List<tblOutstandingMasterEntity>> Update(tblOutstandingMasterEntity entity)
        {
            _sqlDBContext.tblOutstandingMaster.AddOrUpdate(entity);
            return await GetOutstanding();
        }

        public async Task<List<tblOutstandingMasterEntity>> GetOutstanding()
        {
            return _sqlDBContext.tblOutstandingMaster.ToList();
        }

        public async Task<DataSet> GetOutstandingCustomers()
        {
            return _sqlDbHelper.FunExecuteDataSet("GetOutstandingCustomer");
        }

        public async Task<DataSet> GetOutstandingForSelectedCustomer(string customerID)
        {
            return _sqlDbHelper.FunExecuteDataSet("GetOutstandingSelectedCustomer", customerID);
        }

        public async Task<bool> DeleteCustomerPending(long billID)
        {
           var result= _sqlDbHelper.FunExecuteNonQuery("DeleteCustomerPending", billID);

            if(result==1)
            { return true; }
            else { return false; } 
        }

        public async Task InsertUpdatePendingAmount(long BillID, long CustomerID, decimal Amount,string Date)
        {
            _sqlDbHelper.FunExecuteNonQuery("[InsertUpdateOutStanding]", CustomerID, BillID, Amount, Date);
        }
    }
}
