using StockXBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXCore
{
    public static class GlobalCollection
    {
        public static List<CustomerMasterEntity> lstAllCustomerInfo = new List<CustomerMasterEntity>();

        public static DataSet dsCurrentLoginUserDetails = null;
        public static DataSet dsPendingResult = new DataSet();
        public static DataSet dsStockDetails=new DataSet();
        public static DataSet dsAppSettings = new DataSet();
    }
}
