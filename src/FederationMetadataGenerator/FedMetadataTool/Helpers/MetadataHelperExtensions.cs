using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace CedarLogic.Identity
{
    public static class MetadataHelperExtensions
    {
        public static void ToXml(this MetadataDescriptor obj, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                XmlSerializer ser = new XmlSerializer(obj.GetType());
                ser.Serialize(writer, obj);
                writer.Flush();
            }
        }

        public static T ToObject<T>(this MetadataDescriptor obj, string fileName) where T : MetadataDescriptor
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                var rv = ser.Deserialize(reader) as T;
                return rv;
            }
        }



    }
}
