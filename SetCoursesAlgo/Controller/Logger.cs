using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCourse.App.Classes
{
    class Logger
    {
        private static string sLogPath = SetCoursesAlgo.Properties.Settings.Default.LogPath;

        public static void LogMessageToFile(string msg)
        {
            System.IO.StreamWriter sw = System.IO.File.AppendText(Logger.sLogPath);
            try
            {
                string logLine = System.String.Format( "{0:G}: {1}.", System.DateTime.Now, msg);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
