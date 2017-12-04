using System;

namespace Logger
{
    class LoggerToXml: ILogger
    {
        /// <summary>
        /// Path to file to write logs
        /// </summary>
        private string Path { get; }

        public LoggerToXml(string path)
        {
            Path = path;
        }

        public void Log(string logMessage)
        {
            var writeToFile = new WriteToFile();
            writeToFile.AddToXml(logMessage, default(LogLevel), DateTime.Now, null, Path);
        }

        public void Log(string logMessage, LogLevel logLevel)
        {

            var writeToFile = new WriteToFile();
            writeToFile.AddToXml(logMessage, logLevel, DateTime.Now, null, Path);
        }

        public void Log(string logMessage, LogLevel logLevel, DateTime dateTime)
        {

            var writeToFile = new WriteToFile();
            writeToFile.AddToXml(logMessage, logLevel, dateTime, null, Path);
        }

        public void Log(string logMessage, LogLevel logLevel, DateTime dateTime, string module)
        {
            var writeToFile = new WriteToFile();
            writeToFile.AddToXml(logMessage,  logLevel,  dateTime, module, Path);
        }
    }
}
