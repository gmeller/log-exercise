using System;
using Exercise.Interfaces;

namespace Exercise.Logger
{
    public class ConsoleLogger: ILogger
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Log(message);
        }

        public void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Log(message);
        }

        public void LogMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Log(message);
        }

        public void Log(string message)
        {
            Console.WriteLine(string.Format("{0}-{1}", DateTime.Now.ToShortDateString(), message));
        }
    }
}
