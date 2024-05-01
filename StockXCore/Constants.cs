using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXCore
{
    public static class Constants
    {
        public static string PRODUCT_NAME { get; set; } = "StokX";

        public static string METHOD_UPDATE { get; set; } = "Update";
        public static string METHOD_SAVE { get; set; } = "Save";

        public static class Message_Types
        {
            public static string DATA_SAVE { get; set; } = "Data Saved Successfully";
            public static string DATA_SAVE_ASK_FOR_BILLPRINT { get; set; } = "Bill Saved Successfully...!, Do you want to print bill";
            public static string BILL_PRINT_DONE { get; set; } = "Bill Printing  Done Please Check";

            public static string DELETE { get; set; } = "Record Deleted Successfully";
        }

        public static class Message_Button_Type
        {
            public static string OK = "Ok";
            public static string YES = "Yes";
            public static string NO = "No";
        }

        public static class Enum
        {
            public static int HUNDRED { get; set; } = 100;
        } 
    }
}
