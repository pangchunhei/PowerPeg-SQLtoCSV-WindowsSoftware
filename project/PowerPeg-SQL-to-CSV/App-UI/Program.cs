using PowerPeg_SQL_to_CSV.Log;
using log4net;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Metadata;
using System.Diagnostics;
//Use xml configuration from app config
//Put this line at the start of the file
[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace App_UI
{
    internal static class Program
    {
        //Put in all class that need log
        private static readonly ILog log = LogHelper.getLogger();

        //Single instance
        static Mutex mutex = new Mutex(false, "powerpeg-db-csv");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            //Log stuff
            log.Info("UI Application starting.");

            // if you like to wait a few seconds in case that the instance is just 
            // shutting down
            if (!mutex.WaitOne(TimeSpan.FromSeconds(2), false))
            {
                log.Info("UI Application already running, no need new instance.");
                MessageBox.Show("Application already started!", "", MessageBoxButtons.OK);
                return;
            }

            try
            {
                log.Info("UI Application started.");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ApplicationConfiguration.Initialize();
                Thread.Sleep(500);

                Application.Run(new HomeForm());
            }
            finally { mutex.ReleaseMutex(); } // I find this more explicit

            log.Info("UI Application shut down.");
        }
    }
}