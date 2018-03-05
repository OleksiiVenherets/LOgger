using System;

namespace Logger
{
    /// <summary>
    /// Interface for Logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Signature of method to logs with 1 parameter
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        void Log(string logMessage);

        /// <summary>
        /// Signature of method to logs with 2 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        void Log(string logMessage, LogLevel logLevel);

        /// <summary>
        /// Signature of method to logs with 3 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        /// <param name="dateTime">Date and time creating logs</param>
        void Log(string logMessage, LogLevel logLevel, DateTime dateTime);

        /// <summary>
        /// Signature of method to logs with 4 parameters
        /// </summary>
        /// <param name="logMessage">Text of message</param>
        /// <param name="logLevel">Level og loggining</param>
        /// <param name="dateTime">Date and time creating logs</param>
        /// <param name="module">Methods which has logs</param>
        void Log(string logMessage, LogLevel logLevel, DateTime dateTime, string module);
    }
}