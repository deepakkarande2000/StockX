using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblExpenseTitleMaster")]
    public class ExpenseTitleMasterEntity
    {
        public Int64 ExpenseID { get; set; }
        public string ExpenseTitle { get; set; }
    }
}
