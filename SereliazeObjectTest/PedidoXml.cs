using System.Xml.Serialization;
using SereliazeObject.Sereliaze;

namespace SereliazeObjectTest
{
    public class PedidoXml : XMLSerialize<Pedido>
    {
        public override XmlAttributeOverrides XMLAtributeOverride()
        {
            this.InsertNameElement(x => x.Nome, "nome");
            return base.XMLAtributeOverride();
        }

        public override XmlSerializerNamespaces XmlSerializerNamespace()
        {
            this.AddValueToMasterNamespace(string.Empty, string.Empty);
            return base.XmlSerializerNamespace();
        }
    }
}
