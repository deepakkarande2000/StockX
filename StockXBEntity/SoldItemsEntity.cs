using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    public class SoldItemsEntity
    {
        public int Counter { get; set; }
        public Int64 BillID { get; set; }
        public Int64 ItemID { get; set; }
        public string ItemName { get; set; }
        public int UnitID { get; set; }
        public string BarcodeID { get; set; }
        public string Date { get; set; }
        public decimal Rate { get; set; }
        public decimal Qty { get; set; }
        public decimal DiscPer { get; set; }
        public decimal DiscAmount { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal? BuyPrice { get; set; }
        public string Weight { get; set; }
        public List<ItemTaxEntity> lstItemTax { get; set; }
    }
}
