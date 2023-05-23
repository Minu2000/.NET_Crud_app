using System.Xml.Serialization;

namespace Minunetcore.Models
{
    [XmlRoot("Datamodels")]
    public class Datamodel
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string ProductName { get; set; }

        //public Datamodel() {
        //       Default constructor required for serialization

        //}

        public Datamodel(int id , string productname) { 
            Id = id;
            ProductName = productname;
        }
    }
}
