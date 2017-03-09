namespace SereliazeObject.XML
{
    using System.Xml.Serialization;
    public class XMLArray
    {
        public string FieldName { get; private set; }
        public XmlArrayAttribute XMLArrayAtribute { get; private set; }
        public bool IgnoreArray { get; private set; }

        public XMLArray(string fieldName, string namespaces = "", bool ignoreElement = false)
        {
            this.FieldName = fieldName;
            this.IgnoreArray = ignoreElement;
            this.XMLArrayAtribute = new XmlArrayAttribute();
            this.XMLArrayAtribute.Namespace = namespaces;
        }

        public XMLArray ChangeNameArray(string nome)
        {
            this.XMLArrayAtribute.ElementName = nome;
            return this;
        }

        public XMLArray ChangeIgoreArray(bool ignore)
        {
            this.IgnoreArray = ignore;
            return this;
        }
    }
}
