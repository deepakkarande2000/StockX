using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXBEntity
{
    [Table("tblShopeeDetails")]
    public class ShopeeDetailEntity
    {
        [Key]
        public string LicenseNo { get; set; }
        public string ShopeeName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
    }
}
