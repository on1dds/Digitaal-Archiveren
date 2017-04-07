using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Abonneren
{


    [XmlRoot("AbonnementenLijst")]
    public class AboLijst
    {
        [XmlArray("Lijst"), XmlArrayItem("Abonnement")]
        public List<Abonnement> Lijst;

        public AboLijst()
        {
            Lijst = new List<Abonnement>();
        }
    }

    [XmlRoot("Abonnement")]

    public class Abonnement
    {
        [XmlElement("Dienst")]
        public string Dienst { get; set; }
        [XmlElement("Alias")]
        public string Alias { get; set; }
        [XmlElement("PuntID")]
        public string PuntID { get; set; }
    }
}
