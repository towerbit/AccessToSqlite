using AccessToSqlite.Core;
using AccessToSQLite.UI;
using System;
using System.Windows.Forms;

namespace AccessToSqlite
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            // TODO: Readme:
            // Ensure download install system compatible Access driver from here:
            // http://www.microsoft.com/download/en/details.aspx?id=13255

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var options = new AccessExportOptions();

            if (args != null && args.Length > 0)
            {
                if (System.IO.File.Exists(args[0]))
                    options.AccessFileName = args[0];

                if (args.Length > 1)
                    options.AccessPassword = args[1];
            }

            Application.Run(new MainForm(options));
        }
    }
}
