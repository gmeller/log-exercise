using System;
namespace Exercise.Enumerables
{
    public enum LogType
    {
        Message,
        Warning,
        Error
    }

    public static class LoggerTypes
    {
        public const string FILE = "FILE";
        public const string CONSOLE = "CONSOLE";
        public const string SQL = "SQL";
    }
}
