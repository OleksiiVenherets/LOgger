using System;

namespace Logger
{
    /// <summary>
    /// Class for logs in Json format
    /// </summary>
    public class LoggerToJson: ILogger
    {
        /// <summary>
        /// Path to file to write logs
        /// </summary>
        private string Path { get; }

        public LoggerToJson(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Method to logs with 1 parameter
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        public void Log(string logMessage)
        {
            var log = new {Message = logMessage};
            var writeToFile = new WriteToFile();
            writeToFile.AddToJson(log, Path);
        }

        /// <summary>
        /// Method to logs with 2 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        public void Log(string logMessage, LogLevel logLevel)
        {
            var log = new
            {
                Message = logMessage,
                Level = logLevel
            };
            var writeToFile = new WriteToFile();
            writeToFile.AddToJson(log, Path);
        }

        /// <summary>
        /// Method to logs with 3 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        /// <param name="dateTime">Date and time creating logs</param>
        public void Log(string logMessage, LogLevel logLevel, DateTime dateTime)
        {
           var log = new
            {
                Message = logMessage,
                Level = logLevel,
                Date = dateTime
            };
            var writeToFile = new WriteToFile();
            writeToFile.AddToJson(log, Path);
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
            var log = new
            {
                Message = logMessage,
                Level = logLevel,
                Date = dateTime,
                Module = module
            };
            var writeToFile = new WriteToFile();
            writeToFile.AddToJson(log, Path);
        }
    }
}
