using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblUnitMaster")]
    public class UnitCategoryEntity
    {
        [Key]
        public int UnitID { get; set; }

        public string UnitName { get; set; }

        public decimal Qty { get; set; }
    }
}
