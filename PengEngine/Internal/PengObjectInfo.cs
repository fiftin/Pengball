using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PengEngine.Internal
{
    public class PengObjectInfo
    {
        [XmlAttribute("type")]
        public string TypeName { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlArray("args"), XmlArrayItem("arg")]
        public PengObjectArgumentInfo[] Arguments { get; set; }
        [XmlElement("content")]
        public string Content { get; set; }
        [XmlArray("props"), XmlArrayItem("prop")]
        public PengPropertyInfo[] Properties { get; set; }
        public PengObjectInfo()
        {
            Arguments = new PengObjectArgumentInfo[0];
            Content = "";
            TypeName = typeof(PengObject).FullName;
            Name = "";
            Properties = new PengPropertyInfo[0];
        }
    }
}
