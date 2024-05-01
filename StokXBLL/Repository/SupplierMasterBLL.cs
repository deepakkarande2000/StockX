using StockXBEntity;
using StokcXDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokXBLL.Repository
{
    public class SupplierMasterBLL:IRepository<SupplierMasterEntity, SupplierMasterEntity>
    {
        SqlDBContext sqlDBContext = new SqlDBContext();

        public async Task<List<SupplierMasterEntity>> AddData(SupplierMasterEntity entity)
        {
            sqlDBContext.tblSupplierMaster.Add(entity);
            sqlDBContext.SaveChanges();
            return await GetAllSuppliers();
        }

        public async Task<List<SupplierMasterEntity>> Delete(SupplierMasterEntity entity)
        {
            sqlDBContext.tblSupplierMaster.Remove(entity);
            sqlDBContext.SaveChanges();
            return await GetAllSuppliers();
        }

        public async Task<List<SupplierMasterEntity>> Update(SupplierMasterEntity entity)
        {
            sqlDBContext.tblSupplierMaster.Add(entity);
            sqlDBContext.SaveChanges();
            return await GetAllSuppliers();
        }

        public async Task<List<SupplierMasterEntity>> GetAllSuppliers()
        {
            return sqlDBContext.tblSupplierMaster.ToList();
        }

    }
}
