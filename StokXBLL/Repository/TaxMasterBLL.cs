using StockXBEntity;
using StokcXDAL;
using StokXBLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokXBLL
{
    public class TaxMasterBLL : IRepository<TaxCategoryEntity, TaxCategoryEntity>,ICRUDRepository<ItemTaxMappingEntity>
    {
        SqlDBContext _sqlDBContext = new SqlDBContext();
        public async Task<List<TaxCategoryEntity>> AddData(TaxCategoryEntity entity)
        {
            try
            {
                _sqlDBContext.TaxCategories.Add(entity);
                _sqlDBContext.SaveChanges();
            }
            catch (Exception)
            {

            }

            return _sqlDBContext.TaxCategories.ToList();
        }

        public async Task<List<TaxCategoryEntity>> Delete(TaxCategoryEntity entity)
        {
            _sqlDBContext.TaxCategories.Remove(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.TaxCategories.ToList();
        }

        public async Task<List<TaxCategoryEntity>> Update(TaxCategoryEntity entity)
        {
            _sqlDBContext.TaxCategories.Add(entity);
            _sqlDBContext.SaveChanges();
            return _sqlDBContext.TaxCategories.ToList();
        }

        public async Task<List<TaxCategoryEntity>> GetAllTaxCategories() {
            return _sqlDBContext.TaxCategories.ToList();
        }

        public async Task<bool> CreateAsync(ItemTaxMappingEntity entity)
        {
            try
            {
                _sqlDBContext.tblItemTaxMapping.Add(entity);
                await _sqlDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<bool> UpdateAsync(ItemTaxMappingEntity entity)
        {
            try
            {
                _sqlDBContext.tblItemTaxMapping.AddOrUpdate(entity);
                await _sqlDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> DeleteAsync(ItemTaxMappingEntity entity)
        {
            try
            {
                _sqlDBContext.tblItemTaxMapping.Remove(entity);
                await _sqlDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<List<ItemTaxMappingEntity>> GetAllItemTaxMapping()
        {
            return _sqlDBContext.tblItemTaxMapping.ToList();
        }


    }
}
