using StockXBEntity;
using StokcXDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokXBLL.Repository
{
    public class PaymentModeBLL:IRepository<PaymentModeEntity,PaymentModeEntity>
    {
        SqlDBContext sqlDBContext = new SqlDBContext();

        public async Task<List<PaymentModeEntity>> AddData(PaymentModeEntity entity)
        {
            sqlDBContext.tblPaymentMode.Add(entity);
            sqlDBContext.SaveChanges();
            return await GetAllPaymentModes();
        }

        public async Task<List<PaymentModeEntity>> GetAllPaymentModes()
        {
            return  sqlDBContext.tblPaymentMode.ToList();
        }

        public async Task<List<PaymentModeEntity>> Delete(PaymentModeEntity entity)
        {
            return await GetAllPaymentModes();

        }

        public async Task<List<PaymentModeEntity>> Update(PaymentModeEntity entity)
        {
            return await GetAllPaymentModes();
        }
    }
}
