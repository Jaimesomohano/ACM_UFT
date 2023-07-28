using APlus_UFT.Library.BaseLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACM_UFT.Library.Base
{
    class Application
    {
        public static void LaunchApp(string app, bool isProcessHaveGUI = true)
        {
            Process process = new Process();
            process.StartInfo.FileName = DirectoryBase.AspenModelerDir;
            process.StartInfo.Arguments = _products[app];
            process.Start();

            if (isProcessHaveGUI == true)
            {
                process.WaitForInputIdle();
                int i = 0;
                while (process.MainWindowHandle == IntPtr.Zero)
                {
                    Thread.Sleep(100);
                    process.Refresh();
                    i++;
                    if (i > 3000)
                    {
                        Logger.Error($"Time Out! Application {process.ProcessName} GUI cannot be Launched over 5 minutes");
                        break;
                    }
                }
            }
        }
        public static Dictionary<string, string> _products = new Dictionary<string, string>
        {
            { "Aspen Custom Modeler", null },
            { "Aspen Adsorption", "ADS" },
        };
    }
}
