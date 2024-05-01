using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    public class ItemTaxEntity
    {
        public Int64 ItemID { get; set; }
        public string TaxName { get; set; }
        public int TaxID { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
