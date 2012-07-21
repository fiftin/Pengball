using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PengEngine.Internal
{
    [XmlRoot("world")]
    public class PengWorldInfo
    {
        [XmlArray("objects"), XmlArrayItem("object")]
        public PengObjectInfo[] Objects { get; set; }
    }
}
