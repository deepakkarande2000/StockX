using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblDailyExpenses")]
   public class DailyExpenseEntity
    {
        [Key]
        public Int64 ID { get; set; }
        public Int64 ExpenseID { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMode { get; set; }
        public string Description { get; set; }
        public Int64 PaidBy { get; set; }

    }
}
