using StockXBEntity;
using StockXCore;
using StokcXDAL;
using StokXDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokXBLL.Repository
{
   
    public class CustomerMasterBLL:IRepository<CustomerMasterEntity,CustomerMasterEntity>
    {
        SqlDBContext sqlDBContext = new SqlDBContext();
        SqlDbHelper sqlDbHelper = new SqlDbHelper();
        public async Task<List<CustomerMasterEntity>> AddData(CustomerMasterEntity entity)
        {
            sqlDBContext.tblCustomerMaster.Add(entity);
            sqlDBContext.SaveChanges();
            return await GetAllCustomers();
        }

        public async Task<List<CustomerMasterEntity>> Delete(CustomerMasterEntity entity)
        {
            sqlDBContext.tblCustomerMaster.Remove(entity);
            sqlDBContext.SaveChanges();
            return await GetAllCustomers();
        }

        public async Task<List<CustomerMasterEntity>> Update(CustomerMasterEntity entity)
        {
            sqlDBContext.tblCustomerMaster.Add(entity);
            sqlDBContext.SaveChanges();
            return await GetAllCustomers();
        }

        public async Task<List<CustomerMasterEntity>> GetAllCustomers()
        {
            GlobalCollection.lstAllCustomerInfo= sqlDBContext.tblCustomerMaster.ToList();
            return sqlDBContext.tblCustomerMaster.ToList();
        }

        public async Task<DataSet> SelectedCustomer(string text)
        {
            return sqlDbHelper.FunExecuteDataSet("GetCustomerDetailFromBill", text);
        }
    }
}
