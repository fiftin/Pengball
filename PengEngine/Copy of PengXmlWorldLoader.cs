using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using System.Xml.XPath;
namespace PengEngine2
{
    public class PengXmlWorldTagsAndAttributes
    {
        public string ObjectList { get; set; }
        public string Object { get; set; }
        public string ObjectID { get; set; }
        public string ObjectArgList { get; set; }
        public string ObjectArg { get; set; }
        public string ObjectArgName { get; set; }
        public string ObjectType { get; set; }
        public string ArgumentType { get; set; }

        public PengXmlWorldTagsAndAttributes()
        {
            ObjectList = "objects";
            Object = "object";
            ObjectID = "id";
            ObjectArg = "argument";
            ObjectArgList = "arguments";
            ObjectArgName = "name";
            ArgumentType = "type";
            ObjectType = "type";
        }

        public string XPathObjects
        {
            get
            {
                return ObjectList + "/" + Object;
            }
        }

        public string XPathObjectArgs
        {
            get
            {
                return Object + "/" + ObjectArgList;
            }
        }

        
    }

    public class PengXmlWorldLoader
    {

        public class ObjectArgumentInfo
        {
            public ObjectArgumentInfo(Type type, object value)
            {
                Type = type;
                Value = value;
            }

            public Type Type { get; set; }
            public object Value { get; set; }
        }

        public PengXmlWorldTagsAndAttributes TA
        {
            get;
            set;
        }

        public PengXmlWorldLoader()
        {
            TA = new PengXmlWorldTagsAndAttributes();
        }

        public ObjectArgumentInfo GetObjectArgFromXml(XElement xArg)
        {
            Type argType;
            if (xArg.Attribute(TA.ArgumentType) != null)
            {
                argType = Type.GetType(xArg.Attribute(TA.ArgumentType).Value);
            }
            else
            {
                argType = typeof(string);
            }
            object argValue;
            if (argType == typeof(string))
                argValue = xArg.Value;
            else if (argType == typeof(int))
                argValue = int.Parse(xArg.Value);
            else if (argType == typeof(float))
                argValue = float.Parse(xArg.Value);
            else
                throw new ArgumentException("xArg");

            return new ObjectArgumentInfo(argType, argValue);
        }

        public virtual void Load(PengWorld world, XElement xWorld)
        {
            Contract.Requires(world != null);
            Contract.Requires(xWorld != null);

            foreach (XElement xObj in xWorld.XPathSelectElements(TA.XPathObjects))
            {
                List<ObjectArgumentInfo> args = new List<ObjectArgumentInfo>();
                args.Add(new ObjectArgumentInfo(typeof(string), xObj.Attribute(TA.ObjectID).Value));
                Type objectType;
                if (xObj.Attribute(TA.ObjectType) != null)
                {
                    objectType = Type.GetType(xObj.Attribute(TA.ObjectType).Value);
                    foreach (XElement xArg in xWorld.XPathSelectElements(TA.XPathObjectArgs))
                    {
                        if (xArg.Attribute(TA.ArgumentType) != null)
                            args.Add(GetObjectArgFromXml(xArg));
                    }
                }
                else
                    objectType = typeof(PengObject);

                var ctor = objectType.GetConstructor(args.ConvertAll(x => x.Type).ToArray());
                PengObject obj = (PengObject)ctor.Invoke(args.ConvertAll(x => x.Value).ToArray());
                obj.LoadFromXml(xObj);
            }


        }

        public void Load(PengWorld world, XmlReader reader)
        {
            //Contract.Requires(world != null);
            //Contract.Requires(uri != null);

            XDocument document = XDocument.Load(reader);
            Load(world, document.Root);
        }

        public static PengXmlWorldLoader Instance
        {
            get
            {
                if (instance != null)
                    instance = new PengXmlWorldLoader();
                return instance;
            }
        }

        private static PengXmlWorldLoader instance;
    }
}
