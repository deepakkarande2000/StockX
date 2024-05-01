using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblBillPaymentDetails")]
    public class BillPaymentEntity
    {
        [Key]
        public Int64 BillID { get; set; }
        [Key]
        public int PaymentMode { get; set; }
        public string BillDate { get; set; }
        public decimal Amount { get; set; }
    }
}
