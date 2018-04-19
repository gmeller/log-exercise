using Exercise.Interfaces;
using System.Data.SqlClient;
using System.Configuration;

namespace Exercise.Logger
{
    public class SQLLogger: ILogger
    {
        private int _logType = 1;
        public void LogError(string message)
        {
            _logType = 1;
            Log(message);
        }

        public void LogWarning(string message)
        {
            _logType = 2;
            Log(message);
        }

        public void LogMessage(string message)
        {
            _logType = 3;
            Log(message);
        }

        public void Log(string message)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
            {
                connection.Open();
                var command = string.Format("InsertintoLogValues('{0}',{1})", message, _logType);
                SqlCommand sqlCommand = new SqlCommand(command);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
