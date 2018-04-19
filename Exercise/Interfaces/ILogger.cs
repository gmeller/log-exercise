namespace Exercise.Interfaces
{
    public interface ILogger
    {
        /// <summary>
        /// Implements a new log line
        /// </summary>
        /// <param name="message">Message to log</param>
        void Log(string message);

        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="message">Message to log</param>
        void LogMessage(string message);

        /// <summary>
        /// Logs a warning
        /// </summary>
        /// <param name="message">Message to log</param>
        void LogWarning(string message);

        /// <summary>
        /// Logs an error
        /// </summary>
        /// <param name="message">Message to log</param>
        void LogError(string message);
    }
}
