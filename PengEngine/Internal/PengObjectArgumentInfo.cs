using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PengEngine.Internal
{
    public class PengObjectArgumentInfo
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlElement("v")]
        public string Value { get; set; }

        public PengObjectArgumentInfo()
        {
            Type = "System.String";
            Value = "";
        }

        public PengObjectArgumentInfo(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
