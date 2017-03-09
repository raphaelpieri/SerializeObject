namespace SereliazeObject.Interfaces
{
    using System.Xml.Serialization;

    public interface IXMLSerialize
    {
        XmlAttributeOverrides XMLAtributeOverride();
        XmlSerializerNamespaces XmlSerializerNamespace();
    }
}
