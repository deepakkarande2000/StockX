using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblBillTax")]
    public class BillTaxEntity
    {
        public Int64 BillID { get; set; }
        public Int64 ItemID { get; set; }
        public int TaxID { get; set; }
        public decimal TaxAmount { get; set; }
        public string Date { get; set; }
    }
}
