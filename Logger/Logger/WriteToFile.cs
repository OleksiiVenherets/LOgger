using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

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

            using (var sWriter = new StreamWriter(path + "log.txt", true, Encoding.Default))
            {
                sWriter.WriteLine(sbuilder);
            }
        }

        public void AddToXml(string logMessage, LogLevel logLevel, DateTime dateTime, string module, string path)
        {
            if (!File.Exists(path + "\\log.xml"))
            {
                var xmlWriterSettings = new XmlWriterSettings
                {
                    Indent = true,
                    NewLineOnAttributes = true
                };
                using (var xmlWriter = XmlWriter.Create(path + "\\log.xml", xmlWriterSettings))
                {
                    xmlWriter.WriteStartElement("Logs");
                    xmlWriter.WriteElementString("message", logMessage);
                    xmlWriter.WriteElementString("loglevel", logLevel.ToString());
                    xmlWriter.WriteElementString("module", module);
                    xmlWriter.WriteElementString("date", dateTime.ToString(CultureInfo.InvariantCulture));
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                }
            }
            else
            {
                var doc = XDocument.Load(path + "\\log.xml");
                var root = new XElement("log");
                root.Add(new XElement("message", logMessage));
                root.Add(new XElement("loglevel", logLevel.ToString()));
                root.Add(new XElement("module", module));
                root.Add(new XElement("date", dateTime.ToString(CultureInfo.InvariantCulture)));
                doc.Element("Logs").Add(root);
                doc.Save(path + "\\log.xml");
            }

        }

        public void AddToJson(object log, string path)
        {
            if (!File.Exists(path + "\\log.json"))
            {
                using (var fStream = new FileStream(path + "\\log.json", FileMode.Append, FileAccess.Write))
                {
                    using (var sWriter = new StreamWriter(fStream))
                    {
                        sWriter.Write(JObject.FromObject(log).ToString());
                    }
                }
            }
            else
            {
                using (var fStream = new FileStream(path + "\\log.json", FileMode.Append, FileAccess.Write))
                {
                    using (var sWriter = new StreamWriter(fStream))
                    {
                        sWriter.WriteLine(JObject.FromObject(log) + "\n");
                    }
                }

            }
        }
    }
}