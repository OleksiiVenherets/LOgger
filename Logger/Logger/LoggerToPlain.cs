using System;
using System.Text;

namespace Logger
{
    public class LoggerToPlain: ILogger
    {
        /// <summary>
        /// Path to file to write logs
        /// </summary>
        private string Path { get; }

        public LoggerToPlain(string path)
        {
            Path = path;
        }
        
        public void Log(string logMessage)
        { 
            var sbuilder = new StringBuilder(logMessage);
            var writeToFile = new WriteToFile();
            writeToFile.AddToPlain(sbuilder, Path);
        }

        public void Log(string logMessage, LogLevel logLevel)
        {
            var sbuilder = new StringBuilder(logMessage);
            sbuilder.Append("Level: ");
            sbuilder.Append(logLevel);
            var writeToFile = new WriteToFile();
            writeToFile.AddToPlain(sbuilder, Path);
        }

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