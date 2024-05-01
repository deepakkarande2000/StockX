using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblItemMaster")]
    public class ItemMasterEntity
    {
        public Int64 ID { get; set; }
        public string ItemName { get; set; }
        public string BarcodeID { get; set; }
        public decimal Rate { get; set; }

        public Int64 CategoryID { get; set; }
        public int UnitID { get; set; }
        public int ApplyTax { get; set; }
        public decimal? DiscPer { get; set; }
        public decimal? DiscAmount { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Total { get; set; }
        public decimal? BuyPrice { get; set; }
        
    }
}
