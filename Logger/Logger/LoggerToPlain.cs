using System;
using System.Text;

namespace Logger
{
    public class LoggerToPlain: ILogger
    {
        /// <summary>
        /// Class for logs in txt format
        /// </summary>
        private string Path { get; }

        public LoggerToPlain(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Method to logs with 1 parameter
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        public void Log(string logMessage)
        { 
            var sbuilder = new StringBuilder(logMessage);
            var writeToFile = new WriteToFile();
            writeToFile.AddToPlain(sbuilder, Path);
        }

        /// <summary>
        /// Method to logs with 2 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        public void Log(string logMessage, LogLevel logLevel)
        {
            var sbuilder = new StringBuilder(logMessage);
            sbuilder.Append("Level: ");
            sbuilder.Append(logLevel);
            var writeToFile = new WriteToFile();
            writeToFile.AddToPlain(sbuilder, Path);
        }

        /// <summary>
        /// Method to logs with 3 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        /// <param name="dateTime">Date and time creating logs</param>
        public void Log(string logMessage, LogLevel logLevel, DateTime dateTime)
        {
            var sbuilder = new StringBuilder(logMessage);
            sbuilder.Append("Level: ");
            sbuilder.Append(logLevel);
            sbuilder.Append("Date: ");
            sbuilder.Append(dateTime);
            var writeToFile = new WriteToFile();
            writeToFile.AddToPlain(sbuilder, Path);
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
            var sbuilder = new StringBuilder(logMessage);
            sbuilder.Append("Level: ");
            sbuilder.Append(logLevel);
            sbuilder.Append("Date: ");
            sbuilder.Append(dateTime);
            sbuilder.Append("Module: ");
            sbuilder.Append(module);
            var writeToFile = new WriteToFile();
            writeToFile.AddToPlain(sbuilder, Path);
        }
    }
}