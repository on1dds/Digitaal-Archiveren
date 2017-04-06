using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Abonneren.forms
{


    [XmlRoot("AbonnementenLijst")]
    public class AbonnementenLijst
    {
        [XmlArray("Lijst"), XmlArrayItem("Abonnement")]
        public List<Abonnement> Lijst;

        public AbonnementenLijst()
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
