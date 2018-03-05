using System;

namespace Logger
{
    /// <summary>
    /// Class for logs in XML format
    /// </summary>
    public class LoggerToXml: ILogger
    {
        /// <summary>
        /// Path to file to write logs
        /// </summary>
        private string Path { get; }

        public LoggerToXml(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Method to logs with 1 parameter
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        public void Log(string logMessage)
        {
            var writeToFile = new WriteToFile();
            writeToFile.AddToXml(logMessage, default(LogLevel), DateTime.Now, null, Path);
        }

        /// <summary>
        /// Method to logs with 2 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        public void Log(string logMessage, LogLevel logLevel)
        {

            var writeToFile = new WriteToFile();
            writeToFile.AddToXml(logMessage, logLevel, DateTime.Now, null, Path);
        }

        /// <summary>
        /// Method to logs with 3 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        /// <param name="dateTime">Date and time creating logs</param>
        public void Log(string logMessage, LogLevel logLevel, DateTime dateTime)
        {

            var writeToFile = new WriteToFile();
            writeToFile.AddToXml(logMessage, logLevel, dateTime, null, Path);
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
            var writeToFile = new WriteToFile();
            writeToFile.AddToXml(logMessage,  logLevel,  dateTime, module, Path);
        }
    }
}
