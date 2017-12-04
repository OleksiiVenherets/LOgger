using System;

namespace Logger
{
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

        public void Log(string logMessage)
        {
            var log = new {Message = logMessage};
            var writeToFile = new WriteToFile();
            writeToFile.AddToJson(log, Path);
        }

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
