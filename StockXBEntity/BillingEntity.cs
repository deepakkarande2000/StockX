using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    public class BillingEntity
    {
        public Int64 SrNo { get; set; }
        public Int64 BillID { get; set; }
        public string Date { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TotalBillAmount { get; set; }
        public Int64? CustomerID { get; set; }
    }
}
