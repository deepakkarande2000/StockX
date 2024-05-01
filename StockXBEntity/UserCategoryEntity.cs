using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblUserCategoryMaster")]
    public class UserCategoryEntity
    {
        public int ID { get; set; }
        public string  CategoryName { get; set; }
    }
}
