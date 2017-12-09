using System;
using System.Linq;
using System.Configuration;

namespace Logger
{
    public class ReadSettings : IDisposable
    {
        /// <summary>
        /// Method for reading settings from config file
        /// </summary>

        public void ReadFromConfig(ref string path, ref LogLevel level, ref LogFormat format)
        {
            path = ConfigurationManager.AppSettings["filepath"];

            foreach (var loglevel in Enum.GetValues(typeof(LogLevel)).Cast<object>().Where(loglevel => loglevel.ToString() == ConfigurationManager.AppSettings["loglevel"]))
            {
                level = (LogLevel)loglevel;
            }


            foreach (var logformat in Enum.GetValues(typeof(LogFormat)).Cast<object>().Where(logformat => logformat.ToString() == ConfigurationManager.AppSettings["filetype"]))
            {
                format = (LogFormat)logformat;
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                this.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ReadSettings()
        {
            Dispose(false);
        }
    }
}