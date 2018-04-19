using Exercise.Interfaces;
using Exercise.Enumerables;
using Exercise.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace Exercise.Business
{
    public static class LogManager
    {
        /// <summary>
        /// Logs into loggers the message provided.
        /// </summary>
        /// <param name="type">Type of message (error, warning or message).</param>
        /// <param name="message">Message to log.</param>
        /// <param name="logConfiguration">Configuration to get loggers and log types to log.</param>
        public static void Log(LogType type, string message, ILogConfiguration logConfiguration = null)
        {
            //TODO: Make a cache for configuration
            //Gets configuration in the case that user doesnt provide it
            if(logConfiguration == null)
                logConfiguration = new LogConfiguration();

            //If there are no loggers
            if (logConfiguration.Loggers.Count() == 0)
                throw new System.Exception("Invalid Configuration");

            //If there is nothing configured to be logged
            if(!logConfiguration.LogError && !logConfiguration.LogMessage && !logConfiguration.LogError)
                throw new System.Exception("Error or Warning or Message must be specified");

            //Process the log
            ProcessLog(type, message, logConfiguration);
        }

        private static void ProcessLog(LogType type, string message, ILogConfiguration logConfiguration)
        {
            foreach (var logger in logConfiguration.Loggers)
            {
                switch (type)
                {
                    case LogType.Message:
                        if (logConfiguration.LogMessage)
                            logger.LogMessage(message);
                        break;
                    case LogType.Warning:
                        if (logConfiguration.LogWarning)
                            logger.LogWarning(message);
                        break;
                    case LogType.Error:
                        if (logConfiguration.LogError)
                            logger.LogError(message);
                        break;
                }
            }
        }
    }
}
