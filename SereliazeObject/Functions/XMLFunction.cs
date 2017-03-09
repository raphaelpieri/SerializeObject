using SereliazeObject.Interfaces;

namespace SereliazeObject.Functions
{
    using SereliazeObject.Interfaces;
    using System.IO;
    using System.Xml.Serialization;

    public class XMLFunction<T>
    {
        private readonly T _object;
        private readonly IXMLSerialize _xmlSerialize;
        public XMLFunction(T tObject, IXMLSerialize xmlSerialize)
        {
            _object = tObject;
            _xmlSerialize = xmlSerialize;
        }

        public TextWriter XmlSerializer(TextWriter textReturn)
        {
            var serializer = new XmlSerializer(this._object.GetType(), _xmlSerialize.XMLAtributeOverride());
            serializer.Serialize(textReturn, this._object, this._xmlSerialize.XmlSerializerNamespace());
            return textReturn;
        }
    }
}
