using FluentValidator;
using SereliazeObject.Shared;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SereliazeObjectTest
{

    [XmlType(TypeName = "pedido")]
    public class Pedido : Entity
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Idade { get; set; }
        public int Tamanho { get; set; }
        public IList<Item> Items { get; set; }        
    }
}
