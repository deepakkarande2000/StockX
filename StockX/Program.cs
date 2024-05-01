using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockX
{
    internal static class Program
    {
        const string appKey = "213213RTVR-5RR554FTGD-RTYUTYRBUJ-RAQWTJHBRT";
        static bool createdNew;
        static Mutex mutex = new Mutex(true, appKey, out createdNew);
      


    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
        static void Main()
        {
            if (!createdNew)
            {
                // myApp is already running...
                MessageBox.Show("StokX Application is already running!", "Multiple Instances");
                return;
            }
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmDashboard());
        }

        private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine(e.Message + " | " + e.StackTrace + "|" + e.InnerException.ToString());
        }
    }
}
