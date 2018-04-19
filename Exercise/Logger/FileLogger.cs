using System;
using Exercise.Interfaces;
using System.Configuration;

namespace Exercise.Logger
{
    public class FileLogger: ILogger
    {
        public void LogError(string message)
        {
            Log(message);
        }

        public void LogWarning(string message)
        {
            Log(message);
        }

        public void LogMessage(string message)
        {
            Log(message);
        }

        public void Log(string message)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(string.Format("{0}\\{1}_{2}{3}", ConfigurationManager.AppSettings["LogFileDirectory"], ConfigurationManager.AppSettings["LogFileName"], DateTime.Now.ToString("yyyyMMdd"), ConfigurationManager.AppSettings["LogFileExtension"]),true))
            {
                sw.WriteLine(message,true);
            }
        }
    }
}
