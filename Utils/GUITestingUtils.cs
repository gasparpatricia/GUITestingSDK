using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GUITestingSDK
{
    public class GUITestingUtils
    {
        static Process process;
        public static void LaunchApplication(string filePath, string args = "")
        {
            //String path = System.Configuration.ConfigurationManager.AppSettings["processPath"];
           // process = new Process();
            //process.StartInfo.FileName = filePath;
            process = Process.Start(filePath);
        }

        public static void CloseApplication(string execName = "")
        {
            process.Kill();
        }
    }
}
