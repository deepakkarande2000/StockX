using StockXBEntity;
using StokcXDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokXBLL.Repository
{
    public class UnitMasterBLL : IRepository<UnitCategoryEntity, UnitCategoryEntity>
    {
        SqlDBContext _sqlDBContext = new SqlDBContext();

        public async Task<List<UnitCategoryEntity>> AddData(UnitCategoryEntity entity)
        {
            _sqlDBContext.UnitCategories.Add(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.UnitCategories.ToList();   
        }

        public async Task<List<UnitCategoryEntity>> Delete(UnitCategoryEntity entity)
        {
            UnitCategoryEntity unitCategoryEntity = new UnitCategoryEntity() { UnitID=entity.UnitID};
            _sqlDBContext.UnitCategories.Remove(unitCategoryEntity);            
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.UnitCategories.ToList();
        }

        public async Task<List<UnitCategoryEntity>> Update(UnitCategoryEntity entity)
        {
            _sqlDBContext.UnitCategories.Add(new UnitCategoryEntity{
                Qty = entity.Qty,
                UnitName = entity.UnitName,
                UnitID=entity.UnitID,
            });
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.UnitCategories.ToList();
        }


        public async Task<List<UnitCategoryEntity>> GetAllUnits()
        {
            return _sqlDBContext.UnitCategories.ToList();
        }
    }
}
