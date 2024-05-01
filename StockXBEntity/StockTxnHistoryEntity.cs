using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblStockTxnHistory")]
    public class StockTxnHistoryEntity
    {
        [Key]
        public Int64 ID { get; set; }
        public Int64? ItemID { get; set; }
        public int? UnitID { get; set; }
        public decimal? Qty { get; set; }
        public string PurchaseDate { get; set; }
        public string BillNo { get; set; }
        public Int64? SupplierID { get; set; }
        public decimal?  Price { get; set; }
        public decimal?  Total { get; set; }
    }
}
