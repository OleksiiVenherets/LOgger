using System;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;
using System.Text;

using System.Xml;

namespace Logger
{
    internal class WriteToFile
    {
        public void AddToPlain(StringBuilder sbuilder, string path)
        {
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using (var sWriter = new StreamWriter(path + "\\log.txt", true, System.Text.Encoding.Default))
            {
                sWriter.WriteLine(sbuilder);
            }
        }

        public void AddToXml(string logMessage, LogLevel logLevel, DateTime dateTime, string module, string path)
        {
            if (!File.Exists(path + "\\log.xml"))
            {
                var xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(path + "\\log.xml", xmlWriterSettings))
                {
                    xmlWriter.WriteElementString("message", logMessage);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteElementString("loglevel", logLevel.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteElementString("name", module);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteElementString("date", dateTime.ToString(CultureInfo.CurrentCulture));
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                }
            }
            else
            {
                XmlDocument doc = new XmlDocument(); doc.Load(path + "\\log.xml");
                using (XmlWriter xmlWriter = doc.CreateNavigator().AppendChild())
                {
                    xmlWriter.WriteElementString("message", logMessage);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteElementString("loglevel", logLevel.ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteElementString("name", module);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteElementString("date", dateTime.ToString(CultureInfo.CurrentCulture));
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                }
            }
        }

        public void AddToJson(object log, string path)
        {
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            using (StreamWriter file = File.CreateText(path + "\\log.json"))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, log);
            }
        }
    }
}