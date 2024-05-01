using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockXExceptionLogger
{
    public static class ExceptionLogger
    {
        public static void WriteExceptionLog(Exception exception)
        {
            Console.WriteLine(exception.ToString());
        }

    }
}
