using StockXBEntity;
using StokcXDAL;
using StokXDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace StokXBLL.Repository
{
    public class BillingBLL
    {
        SqlDBContext _sqlDBContext = new SqlDBContext();
        public SqlDbHelper _sqlDbHelper = new SqlDbHelper();
        public bool AddData(BillingEntity entity, List<BillItemsEntity> billItemsEntity,
            List<BillPaymentEntity> billPaymentEntity, List<BillTaxEntity> billTaxEntity,
            List<tblOutstandingMasterEntity> tblOutstandingMasters, List<tblOutstandingTxnEntity> lstOutstandingTxn)
        {
            try
            {
                var resul = _sqlDbHelper.FunExecuteNonQuery("InsertUpdateBillingDetails", entity.SrNo,
                    entity.BillID, entity.Date, entity.TotalBillAmount, entity.CustomerID, entity.TotalTax, entity.TotalDiscount);

                foreach (var item in billItemsEntity)
                {
                    _sqlDbHelper.FunExecuteNonQuery("InsertUpdateBillingItemsDetails",
                        item.BillID, item.ItemID, item.UnitID, item.Date, item.Rate, item.Qty,
                        item.DiscPer, item.DiscAmount,item.TaxAmount, item.Total);
                    _sqlDbHelper.FunExecuteNonQuery("AddSubstractStock", item.ItemID, item.UnitID, item.Qty, 0);
                }
                foreach (var item in billPaymentEntity)
                {
                    _sqlDbHelper.FunExecuteNonQuery("InsertUpdateBillPaymentDetails", item.BillID, item.BillDate, item.PaymentMode, item.Amount);
                }
                foreach (var item in billTaxEntity)
                {
                    _sqlDbHelper.FunExecuteNonQuery("InsertUpdateBillTaxDetails", item.BillID, item.ItemID, item.TaxID, item.TaxAmount, item.Date);
                }
                foreach (var item in tblOutstandingMasters)
                {
                    _sqlDbHelper.FunExecuteNonQuery("InsertUpdateOutStanding", item.CustomerID, item.BillID,item.Outstanding);
                }
                foreach (var item in lstOutstandingTxn)
                {
                    _sqlDbHelper.FunExecuteNonQuery("InsertUpdateOutStandingTxn", item.CustomerID, item.paidAmount, item.TxnDate);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public async Task<bool> Delete(tblBilling entity)
        {
            _sqlDBContext.tblBillDetail.Remove(entity);
            _sqlDBContext.tblBillItems.Remove(new BillItemsEntity() { BillID = entity.BillID });
            _sqlDBContext.tblBillPayment.Remove(new BillPaymentEntity() { BillID = entity.BillID });
            _sqlDBContext.tblBillTax.Remove(new BillTaxEntity() { BillID = entity.BillID });
            _sqlDBContext.SaveChanges();
            return true;
        }



        public async Task<DataSet> GetAllBillDetailsForDate(string Date)
        {
            return _sqlDbHelper.FunExecuteDataSet("GetAllBillDetailsByDate", Date);
        }

        public async Task<DataSet> GetBillDetails(string billID)
        {
            return _sqlDbHelper.FunExecuteDataSet("[GetBillDetails]", billID);
        }

        public async Task<long> GetLatestBillID(DateTime date)
        {

            string Datecomparer = date.ToString("yyyyMMdd");
            if (_sqlDBContext.tblBillDetail.Where(x => x.Date == Datecomparer).Select(c => c.BillID).Any())
            {
                dynamic MaxID = _sqlDBContext.tblBillDetail
                    .Where(x => x.Date == Datecomparer)
                    .Select(c => new { c.BillID, c.SrNo }).Max(c => c.BillID == null ? 1 : c.SrNo);

                if (MaxID == null)
                {
                    return MaxID = 1;
                }
                else
                {
                    return MaxID + 1;
                }
            }
            else { return 1; }
        }
        public DataSet GetTodaysSummaryDetails(string date)
        {
            return _sqlDbHelper.FunExecuteDataSet("GetSummaryForTheDay", date);
        }

        public async Task<bool> Update(tblBilling entity)
        {
            return true;
        }

        public async Task<DataSet> GetBillItems(string BillID)
        {
            return _sqlDbHelper.FunExecuteDataSet("GetBillItemsDetails", BillID);
        }

        public async Task UpdatePaymentDetails(long Bill, string BillDate, int PaymentMode, decimal Amount)
        {
             _sqlDbHelper.FunExecuteNonQuery("InsertUpdateBillPaymentDetails", Bill, BillDate, PaymentMode, Amount);
        }

        public async Task<DataSet> GetSales()
        {
           return _sqlDbHelper.FunExecuteDataSet("GetDayWiseSales");
        }

        public async Task<DataSet> GetBillTax(string BillID)
        {
            return _sqlDbHelper.FunExecuteDataSet("GetBillTaxDetails", BillID);
        }
        public async Task<DataSet> GetBillPayment(string BillID)
        {
            return _sqlDbHelper.FunExecuteDataSet("GetBillPaymentDetails", BillID);
        }
    }
}
