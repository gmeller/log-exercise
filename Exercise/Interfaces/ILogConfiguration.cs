using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Interfaces
{
    public interface ILogConfiguration
    {
        bool LogMessage { get; }

        bool LogError { get; }

        bool LogWarning { get; }

        IEnumerable<ILogger> Loggers { get; }
    }
}
