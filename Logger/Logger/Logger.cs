using System;

namespace Logger
{
    /// <summary>
    /// The main class of dll
    /// </summary>
    public class Logger: ILogger
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
        public Logger()
        {
            var path = "";
            var level = LogLevel.All;
            var format = LogFormat.Plain;
            var readSettings = new ReadSettings();
            readSettings.ReadFromConfig(ref path,  ref level, ref format);
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
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logMessage"></param>
       public void Log(string logMessage)
        {
            _logger.Log(logMessage);
        }

        public void Log(string logMessage, LogLevel logLevel)
        {
            if (logLevel < Level)
                return;
            _logger.Log(logMessage, logLevel);
        }

        public void Log(string logMessage, LogLevel logLevel, DateTime dateTime)
        {
            if (logLevel < Level)
                return;
            _logger.Log(logMessage, logLevel, dateTime);
        }

        public void Log(string logMessage, LogLevel logLevel, DateTime dateTime, string module)
        {
            if (logLevel < Level)
                return;
            _logger.Log(logMessage, logLevel, dateTime, module);
        }
    }
}