using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace w2_volume
{
    static class Program
    {
        private static Mutex mutex = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string appName = "Worms 2 Volume";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew) {
                //app is already running! Exiting the application
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
