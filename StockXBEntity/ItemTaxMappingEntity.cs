using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblItemTaxMapping")]
    public class ItemTaxMappingEntity
    {
        [Key]
        public Int64 ItemID { get; set; }
        [Key]
        public Int64 TaxID { get; set; }
    }
}
