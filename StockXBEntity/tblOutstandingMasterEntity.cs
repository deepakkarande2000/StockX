using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblOutstandingMaster")]
    public class tblOutstandingMasterEntity
    {
        
        public Int64 ID { get; set; }
        public Int64 CustomerID { get; set; }
        [Key]
        public Int64 BillID { get; set; }
        public decimal Outstanding { get; set; }
    }
}
