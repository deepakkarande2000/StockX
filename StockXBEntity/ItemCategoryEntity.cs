using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblItemCategoryMaster")]
    public class ItemCategoryEntity
    {
        public Int64 ID { get; set; }
        public string CategoryName { get; set; }        
    }
}
