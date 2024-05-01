using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblPaymentModeMaster")]
    public class PaymentModeEntity
    {
        public Int64 ID { get; set; }
        public string PaymentMode { get; set; }
    }
}
