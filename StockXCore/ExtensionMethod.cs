using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockXCore
{
    public static class ExtensionMethod
    {
        public static string SetToUpperCase(TextBox textbox)
        {
            if (textbox.Text.Trim() != "")
            {
                return textbox.Text.ToUpper();
            }
            else
            {
                return textbox.Text;
            }
        }

        public static bool ValidateEmail(this string email)
        {
            if (email.Contains("@"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
