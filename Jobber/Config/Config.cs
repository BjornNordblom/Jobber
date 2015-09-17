using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Jobber
{
    public sealed class Config
    {
        private static readonly Config instance = new Config();

        static Config() { }
        private Config() { }

        public void Load(string file)
        {
            var fileinfo = new FileInfo(file);
            if (fileinfo.Attributes.HasFlag(FileAttributes.Directory))
            {                
                foreach (var filename in Directory.GetFiles(file))
                {
                    Load(filename);
                }
            } else { 
                XmlDocument xml = new XmlDocument();
                xml.Load(file);
                Parse(xml);
            }
        }

        private void Parse(XmlDocument xml)
        {
            foreach (XmlNode node in xml.ChildNodes)
            {
                if (node.Name.Equals("job"))
                {
                    JobManager.Instance.Add(new Guid(node.Attributes["id"].Value));
                }
                Console.WriteLine(node.Name);
            }
        }

        public static Config Instance {  get { return instance; } }
    }
}
