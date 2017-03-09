namespace SereliazeObject.XML
{
    using System.Xml.Serialization;
    public class XMLElement
    {
        public string FieldName { get; private set; }
        public XmlElementAttribute XMLElementAtribute { get; private set; }
        public bool IgnoreElement { get; private set; }

        public XMLElement(string fieldName, bool ignoreElement = false)
        {
            this.FieldName = fieldName;
            this.IgnoreElement = ignoreElement;
            this.XMLElementAtribute = new XmlElementAttribute();
        }
  
        public XMLElement ChangeNameElement(string nome)
        {
            this.XMLElementAtribute.ElementName = nome;
            return this;
        }

        public XMLElement ChangeIgoreElement(bool ignore)
        {
            this.IgnoreElement = ignore;
            return this;
        }
    }
}
