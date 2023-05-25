using System.IO;
using System.Xml.Serialization;

namespace Minunetcore.Helpers
{
    public class XmlSerializationHelper
    {
        public static string SerializeToXml<T>(T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, data);
                return stringWriter.ToString();
            }
        }
    }
}
