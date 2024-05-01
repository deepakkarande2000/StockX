using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblUserMaster")]
    public class UserEntity
    {
       
        public Int64 ID { get; set; }
       [Key]
        public string UserName { get; set; }
        public int IsActive { get; set; }
        public string Password { get; set; }
        public int DesignationId { get; set; }
        public int AskToupdatePassword { get; set; }
        public string MobileNo { get; set; }
    }
}
