using System;

namespace Logger
{
    public interface ILogger
    {
        void Log(string logMessage);
        void Log(string logMessage, LogLevel logLevel);
        void Log(string logMessage, LogLevel logLevel, DateTime dateTime);
        void Log(string logMessage, LogLevel logLevel, DateTime dateTime, string module);
    }
}