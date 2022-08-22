using PowerPeg_SQL_to_CSV.Log;
using log4net;
//Use xml configuration from app config
//Put this line at the start of the file
[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace App_UI
{
    internal static class Program
    {
        //Put in all class that need log
        private static readonly ILog log = LogHelper.getLogger();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Log stuff
            log.Info("UI Application starting.");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new HomeForm());

            log.Info("UI Application ending.");
        }
    }
}