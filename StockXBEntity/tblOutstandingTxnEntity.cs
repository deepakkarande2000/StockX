using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblOutstandingTransaction")]
    public class tblOutstandingTxnEntity
    {
        [Key]
        public Int64 ID { get; set; }
        public Int64 CustomerID{ get; set; }
        public string TxnDate { get; set;}
        public decimal paidAmount { get; set; }
    }
}
