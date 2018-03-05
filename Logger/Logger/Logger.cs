using System;

namespace Logger
{
    /// <summary>
    /// The main class of dll
    /// </summary>
    public class Loger: ILogger
    {
        /// <summary>
        /// Path to file to write logs
        /// </summary>
        private string Path { get; }
        /// <summary>
        /// Level fo writing logs
        /// </summary>
        private LogLevel Level { get;  }
        /// <summary>
        /// Type of file to writing logs
        /// </summary>
        private LogFormat Format { get; }

        private readonly ILogger _logger;
        
        /// <summary>
        /// Constructor for logger
        /// </summary>
        /// <param name="path">path to logs file</param>
        /// <param name="level">level of logs</param>
        /// <param name="format">format of log</param>
        public Loger(string path, LogLevel level, LogFormat format)
        {
            Path = path;
            Level = level;
            Format = format;
            switch (Format)
            {
                case LogFormat.Json:
                    _logger = new LoggerToJson(Path);
                    break;
                case LogFormat.Xml:
                    _logger = new LoggerToXml(Path);
                    break;
                case LogFormat.Plain:
                    _logger = new LoggerToPlain(Path);
                    break;
                default:
                    _logger = new LoggerToXml(Path);
                    break;
            }
        }

        /// <summary>
        /// Method to logs with 1 parameter
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        public void Log(string logMessage)
        {
            _logger.Log(logMessage);
        }

        /// <summary>
        /// Method to logs with 2 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        public void Log(string logMessage, LogLevel logLevel)
        {
            if (logLevel < Level)
                return;
            _logger.Log(logMessage, logLevel);
        }

        /// <summary>
        /// Method to logs with 3 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        /// <param name="dateTime">Date and time creating logs</param>
        public void Log(string logMessage, LogLevel logLevel, DateTime dateTime)
        {
            if (logLevel < Level)
                return;
            _logger.Log(logMessage, logLevel, dateTime);
        }

        /// <summary>
        /// Method to logs with 4 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        /// <param name="dateTime">Date and time creating logs</param>
        /// <param name="module">Methods which has logs</param>
        public void Log(string logMessage, LogLevel logLevel, DateTime dateTime, string module)
        {
            if (logLevel < Level)
                return;
            _logger.Log(logMessage, logLevel, dateTime, module);
        }
    }
}