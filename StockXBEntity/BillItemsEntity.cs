using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblBillItems")]
    public class BillItemsEntity
    {
        public Int64 BillID { get; set; }
        public Int64 ItemID { get; set; }        
        public int UnitID { get; set; }        
        public string Date { get; set; }
        public decimal Rate { get; set; }
        public decimal? Qty { get; set; }
        public decimal DiscPer { get; set; }
        public decimal DiscAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }

    }
}
