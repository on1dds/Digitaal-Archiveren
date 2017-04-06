using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace CSVImport
{
    [XmlRoot("SelectieLijst")]
    public class SelectieLijst
    {
        [XmlElement("Gemeente")]
        public string Gemeente;

        [XmlArray("Selectiepunten"), XmlArrayItem("SelectiePunt")]
        public List<SelectiePunt> Selectiepunten;

        public SelectieLijst()
        {
            Selectiepunten = new List<SelectiePunt>();
        }

        public bool Add(SelectiePunt nieuwpunt)
        {
            Selectiepunten.Add(nieuwpunt);
            return true;
        }
    }

    public class SelectiePunt
    {
        CultureInfo provider = CultureInfo.InvariantCulture;

        [XmlAttribute("id")]
        public string id;

        [XmlElement("Volgnummer")]
        public string Volgnummer;

        [XmlElement("Omschrijving")]
        public string Omschrijving;

        [XmlElement("Identificatie")]
        public string Identificatie;

        [XmlElement("Bestemming")]
        public string Bestemming;

        [XmlElement("Selectievoorwaarden")]
        public string Selectievoorwaarden;

        [XmlElement("Vernietigingstermijn")]
        public string Vernietigingstermijn;

        [XmlElement("Historiek")]
        public string Historiek;

        [XmlElement("Publicatie")]
        public string Publicatie;

        [XmlElement("Gewijzigd")]
        public string Gewijzigd;

        [XmlElement("Status")]
        public string Status;

        [XmlElement("Federaal")]
        public string Federaal;

        public string Basisindeling { get { return id.Substring(0, 1); } }
        public string Domein { get { return id.Substring(1, 2); } }
        public string Taak { get { return id.Substring(3, 2); } }
        public string Handeling { get { return id.Substring(5, 2); } }
        public string Document { get { return id.Substring(7, 2); } }

        public bool CSVImport(string[] punt)
        {
            if (punt.Length == 19 || punt.Length == 18)
            {
                id = punt[4] + punt[5].Substring(0, 2);
                Omschrijving = punt[8];
                Identificatie = punt[9];
                Bestemming = punt[10];
                Selectievoorwaarden = punt[11];
                Vernietigingstermijn = punt[12];
                Historiek = punt[13];
                Publicatie = punt[14];
                Gewijzigd = punt[15];
                Status = punt[16];
                Federaal = punt[17];
                return true;
            }
            return false;
        }
    }
}

