using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PengEngine.Internal
{
    public class PengPropertyInfo
    {
        [XmlElement("v")]
        public string Value { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        public PengPropertyInfo()
        {
            Value = "";
            Name = "";
        }
    }
}
