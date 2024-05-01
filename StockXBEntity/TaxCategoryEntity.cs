using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblTaxMaster")]
    public class TaxCategoryEntity
    {
        public Int64 ID { get; set; }
        public string TaxName { get; set; }
        public decimal Percentage { get; set;}
    }
}
