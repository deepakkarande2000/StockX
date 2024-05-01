using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblBilling")]
    public class tblBilling
    {        
        public Int64 SrNo { get; set; }
        [Key]
        public Int64 BillID { get; set; }
        public string Date { get; set; }
        public decimal? TotalBillAmount { get; set; }
        public Int64? CustomerID { get; set; }
    }
}
