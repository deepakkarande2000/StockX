using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblStockMaster")]
    public class StockMasterEntity
    {
        [Key]
        public Int64 ItemID { get; set; }
        public int UnitID { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitQty { get; set; }
    }
}
