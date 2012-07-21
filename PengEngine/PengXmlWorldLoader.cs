using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Serialization;
using PengEngine.Internal;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace PengEngine
{
    public class PengXmlWorldLoader
    {

        public class ObjectArg
        {
            public ObjectArg(Type type, object value)
            {
                Type = type;
                Value = value;
            }

            public Type Type { get; set; }
            public object Value { get; set; }
        }

        private ObjectArg ToObjectArg(PengObjectArgumentInfo argInfo, Func<string, Type> typeProvider)
        {
            var argType = typeProvider(argInfo.Type);
            object argValue;
            if (argType == typeof(string))
                argValue = argInfo.Value;
            else if (argType == typeof(int))
                argValue = int.Parse(argInfo.Value);
            else if (argType == typeof(Vector2))
                argValue = ParseVector2(argInfo.Value);
            else if (argType == typeof(float))
                argValue = float.Parse(argInfo.Value, System.Globalization.CultureInfo.InvariantCulture);
            else if (argType.IsEnum)
                argValue = Enum.Parse(argType, argInfo.Value);
            else
                throw new ArgumentException("argInfo");
            return new ObjectArg(argType, argValue);
        }

        private ObjectArg[] GetObjectArgs(PengObjectInfo objInfo, PengWorld world, Func<string, Type> typeProvider)
        {
            ObjectArg[] ret = new ObjectArg[objInfo.Arguments.Length + 2];
            ret[0] = new ObjectArg(typeof(string), objInfo.Name);
            ret[1] = new ObjectArg(typeof(PengWorld), world);
            for (int i = 0; i < objInfo.Arguments.Length; i++ )
            {
                ret[i + 2] = ToObjectArg(objInfo.Arguments[i], typeProvider);
            }

            return ret;
        }

        private Vector2 ParseVector2(string str)
        {
            string[] s = str.Split(';');
            if (s.Length != 2)
                throw new ArgumentException();
            return new Vector2(float.Parse(s[0], System.Globalization.CultureInfo.InvariantCulture), float.Parse(s[1], System.Globalization.CultureInfo.InvariantCulture));
        }

        private void SetObjectPropertyValue(object obj, PengPropertyInfo prop, PengWorld world)
        {
            Contract.Requires(obj != null);
            Contract.Requires(prop != null);

            var propInfo = obj.GetType().GetProperty(prop.Name);
            object propValue;
            if (propInfo.PropertyType == typeof(int))
                propValue = int.Parse(prop.Value, System.Globalization.CultureInfo.InvariantCulture);
            else if (propInfo.PropertyType == typeof(float))
                propValue = float.Parse(prop.Value, System.Globalization.CultureInfo.InvariantCulture);
            else if (propInfo.PropertyType == typeof(string))
                propValue = prop.Value;
            else if (propInfo.PropertyType == typeof(Texture2D))
                propValue = world.LoadContent<Texture2D>(prop.Value);
            else if (propInfo.PropertyType == typeof(Vector2))
                propValue = ParseVector2(prop.Value);
            else if (propInfo.PropertyType.IsEnum)
                propValue = Enum.Parse(propInfo.PropertyType, prop.Value);
            else
                throw new Exception();
            propInfo.SetValue(obj, propValue, null);
        }

        public void Load(PengWorld world, XmlReader reader, Func<string, Type> typeProvider)
        {
            Contract.Requires(world != null);
            Contract.Requires(reader != null);
            Contract.Requires(typeProvider != null);

            XmlSerializer serializer = new XmlSerializer(typeof(PengEngine.Internal.PengWorldInfo));
            var worldInfo = (PengWorldInfo)serializer.Deserialize(reader);
            foreach (var objInfo in worldInfo.Objects)
            {
                Type objType = typeProvider(objInfo.TypeName);
                ObjectArg[] args = GetObjectArgs(objInfo, world, typeProvider);
                var objCtor = objType.GetConstructor(Array.ConvertAll(args, x => x.Type));
                var obj = (PengObject)objCtor.Invoke(Array.ConvertAll(args, x => x.Value));
                obj.Load(objInfo.Content);
                foreach (var prop in objInfo.Properties)
                    SetObjectPropertyValue(obj, prop, world);
            }
        }

        public static PengXmlWorldLoader Instance
        {
            get
            {
                if (instance == null)
                    instance = new PengXmlWorldLoader();
                return instance;
            }
        }

        private static PengXmlWorldLoader instance;
    }
}
