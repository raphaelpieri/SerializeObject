namespace SereliazeObject.Sereliaze
{
    using System.Xml.Serialization;
    using SereliazeObject.XML;
    using System.Collections.Generic;
    using SereliazeObject.Shared;
    using SereliazeObject.Interfaces;
    using System;
    using System.Linq.Expressions;
    using System.Linq;

    public abstract class XMLSerialize<T> : IXMLSerialize where T : Entity
    {
        private readonly List<XMLArray> _xmlArrays;
        private readonly List<XMLElement> _xmlElements;
        private readonly XmlSerializerNamespaces _xmlSerializerNamespaces;

        public XMLSerialize()
        {
            this._xmlArrays = new List<XMLArray>();
            this._xmlElements = new List<XMLElement>();
            this._xmlSerializerNamespaces = new XmlSerializerNamespaces();
        }

        public XMLSerialize<T> InsertNameArray(Expression<Func<T, string>> field, string value)
        {
            var name = this.ReturnNameField(field);
            var xmlArray = this._xmlArrays.Where(x => x.FieldName == name).FirstOrDefault();
            if (xmlArray != null)
                xmlArray = xmlArray.ChangeNameArray(value);
            else
                this._xmlArrays.Add(new XMLArray(name).ChangeNameArray(value));

            return this;          
        }

        public XMLSerialize<T> InsertNameElement(Expression<Func<T, string>> field, string value)
        {
            var name = this.ReturnNameField(field);
            var xmlElemet = this._xmlElements.Where(x => x.FieldName == name).FirstOrDefault();
            if (xmlElemet != null)
                xmlElemet = xmlElemet.ChangeNameElement(value);
            else
                this._xmlElements.Add(new XMLElement(name).ChangeNameElement(value));
            return this;
        }

        public XMLSerialize<T> IgnoreArray(Expression<Func<T, string>> field, bool value)
        {
            var name = this.ReturnNameField(field);
            var xmlArray = this._xmlArrays.Where(x => x.FieldName == name).FirstOrDefault();
            if (xmlArray != null)
                xmlArray = xmlArray.ChangeIgoreArray(value);
            else
                this._xmlArrays.Add(new XMLArray(name).ChangeIgoreArray(value));

            return this;
        }
        public XMLSerialize<T> IgnoreElement(Expression<Func<T, string>> field, bool value)
        {
            var name = this.ReturnNameField(field);
            var xmlElemet = this._xmlElements.Where(x => x.FieldName == name).FirstOrDefault();
            if (xmlElemet != null)
                xmlElemet = xmlElemet.ChangeIgoreElement(value);
            else
                this._xmlElements.Add(new XMLElement(name).ChangeIgoreElement(value));
            return this;
        }

        public XMLSerialize<T> AddXmlElements(IList<XMLElement> elements)
        {
            this._xmlElements.AddRange(elements);
            return this;
        }

        public XMLSerialize<T> AddXmlArray(IList<XMLArray> arrays)
        {
            this._xmlArrays.AddRange(arrays);
            return this;
        }

        public XMLSerialize<T> AddValueToMasterNamespace(string prefixo, string namespaces)
        {
            this._xmlSerializerNamespaces.Add(prefixo, namespaces);
            return this;
        }

        public virtual XmlAttributeOverrides XMLAtributeOverride()
        {
            var xmlAttributeOverrides = new XmlAttributeOverrides();
            this._xmlElements.ForEach(xmlElement =>
            {
                var xmlAtributes = new XmlAttributes();
                xmlAtributes.XmlElements.Add(xmlElement.XMLElementAtribute);
                xmlAtributes.XmlIgnore = xmlElement.IgnoreElement;
                xmlAttributeOverrides.Add(typeof(T), xmlElement.FieldName, xmlAtributes);
            });

            this._xmlArrays.ForEach(xmlArray =>
            {
                var xmlAttributes = new XmlAttributes();
                xmlAttributes.XmlArray = xmlArray.XMLArrayAtribute;
                xmlAttributes.XmlIgnore = xmlArray.IgnoreArray;
                xmlAttributeOverrides.Add(typeof(T), xmlArray.FieldName, xmlAttributes);
            });

            return xmlAttributeOverrides;
        }

        public virtual XmlSerializerNamespaces XmlSerializerNamespace()
        {
            return this._xmlSerializerNamespaces;
        }

        private string ReturnNameField(Expression<Func<T, string>> field)
        {
            return ((MemberExpression)field.Body).Member.Name;
        }
    }
}
