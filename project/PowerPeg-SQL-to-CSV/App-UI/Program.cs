using PowerPeg_SQL_to_CSV.Log;
using log4net;
using System.Runtime.InteropServices;
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
            NativeMethods.AllocConsole();
            Console.WriteLine("Debug Console");

            //Log stuff
            log.Info("UI Application starting.");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Thread.Sleep(500);
            Application.Run(new HomeForm());

            log.Info("UI Application ending.");

            NativeMethods.FreeConsole();
        }
    }

    internal static class NativeMethods
    {
        // http://msdn.microsoft.com/en-us/library/ms681944(VS.85).aspx
        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns>nonzero if the function succeeds; otherwise, zero.</returns>
        /// <remarks>
        /// A process can be associated with only one console,
        /// so the function fails if the calling process already has a console.
        /// </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int AllocConsole();

        // http://msdn.microsoft.com/en-us/library/ms683150(VS.85).aspx
        /// <summary>
        /// Detaches the calling process from its console.
        /// </summary>
        /// <returns>nonzero if the function succeeds; otherwise, zero.</returns>
        /// <remarks>
        /// If the calling process is not already attached to a console,
        /// the error code returned is ERROR_INVALID_PARAMETER (87).
        /// </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int FreeConsole();
    }
}