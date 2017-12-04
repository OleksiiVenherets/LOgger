using System;
using System.Linq;
using System.Configuration;

namespace Logger
{
    /// <summary>
    /// Class for reading settings
    /// </summary>
    public class ReadSettings
    {
        /// <summary>
        /// Method for reading settings from config file
        /// </summary>
        public void ReadFromConfig(ref string path, ref LogLevel level, ref LogFormat format)
        {
            path = ConfigurationManager.AppSettings["filelocation"];
           foreach (
                var loglevel in
                    Enum.GetValues(typeof(LogLevel))
                        .Cast<LogLevel>()
                        .Where(loglevel => loglevel.ToString() == ConfigurationManager.AppSettings["configlevel"]))
            {
                level = loglevel;
            }

            foreach (
                var logformat in
                    Enum.GetValues(typeof(LogFormat))
                        .Cast<LogFormat>()
                        .Where(logformat => logformat.ToString() == ConfigurationManager.AppSettings["filetype"]))
            {
                format = logformat;
            }
        }   
    }
}