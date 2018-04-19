using Exercise.Interfaces;
using System;
using System.Configuration;
using System.Collections.Generic;
using Exercise.Enumerables;
using Exercise.Logger;

namespace Exercise.Configuration
{
    public class LogConfiguration : ILogConfiguration
    {
        private const char SPLITTER = '|';
        public bool LogMessage { get;}

        public bool LogError { get; }

        public bool LogWarning { get; }

        public IEnumerable<ILogger> Loggers { get; }

        public LogConfiguration()
        {
            LogMessage = Convert.ToBoolean(ConfigurationManager.AppSettings["LogMessage"]);
            LogError = Convert.ToBoolean(ConfigurationManager.AppSettings["LogError"]);
            LogWarning = Convert.ToBoolean(ConfigurationManager.AppSettings["LogWarning"]);

            Loggers = ReadLoggers();
        }

        private IEnumerable<ILogger> ReadLoggers()
        {
            var loggersList = new List<ILogger>();
            var loggersConfigs = ConfigurationManager.AppSettings["Loggers"];

            //If there is no configuration returns an emtpy list
            if (string.IsNullOrEmpty(loggersConfigs))
                return loggersList ;

            var loggersSplitted = loggersConfigs.Split(SPLITTER);
            
            //Match each logger name with the class
            foreach(var loggerName in loggersSplitted)
            {
                switch (loggerName)
                {
                    case LoggerTypes.FILE:
                        loggersList.Add(new FileLogger());
                        break;
                    case LoggerTypes.CONSOLE:
                        loggersList.Add(new ConsoleLogger());
                        break;
                    case LoggerTypes.SQL:
                        loggersList.Add(new SQLLogger());
                        break;
                }
            }

            return loggersList;
        }
    }
}
