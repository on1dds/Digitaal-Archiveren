using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace MaakMappen
{
    public static class Tools
    {
        static public SelectieLijst ReadXML(string fn)
        {
            SelectieLijst lijst = new SelectieLijst();
            TextReader xmlReader;
            XmlSerializer xmlSerial;

            xmlReader = new StreamReader(fn);
            xmlSerial = new XmlSerializer(typeof(SelectieLijst));
            lijst = (SelectieLijst)xmlSerial.Deserialize(xmlReader);
            xmlReader.Close();
            return lijst;
        }

    }

    [XmlRoot("SelectieLijst")]
    public class SelectieLijst
    {
        [XmlElement("Gemeente")]
            public string Gemeente { get; set; }
        [XmlArray("Selectiepunten"), XmlArrayItem("SelectiePunt")]
            public List<SelectiePunt> Selectiepunten { get; set; }

        public SelectieLijst()
        {
            
            Selectiepunten = new List<SelectiePunt>();
        }
        public bool Add(SelectiePunt nieuwpunt)
        {
            // basispunten
            List<SelectiePunt> punten = new List<SelectiePunt>();
            punten = Selectiepunten;
            foreach (SelectiePunt basispunt in punten)
            {
                if (basispunt.Basisindeling == nieuwpunt.Basisindeling)
                {
                    // domeinpunten
                    punten = basispunt.Selectiepunten;
                    foreach (SelectiePunt domeinpunt in punten)
                    {
                        if (domeinpunt.Domein == nieuwpunt.Domein)
                        {
                            // taakpunten
                            punten = domeinpunt.Selectiepunten;
                            foreach (SelectiePunt taakpunt in punten)
                            {
                                if (taakpunt.Taak == nieuwpunt.Taak)
                                {
                                    // Handeling punten
                                    punten = taakpunt.Selectiepunten;
                                    foreach (SelectiePunt handelingpunt in punten)
                                    {
                                        if (handelingpunt.Handeling == nieuwpunt.Handeling)
                                        {
                                            // Handeling punten
                                            punten = handelingpunt.Selectiepunten;
                                            foreach (SelectiePunt documentpunt in punten)
                                            {
                                                if (documentpunt.Document == nieuwpunt.Handeling)
                                                {
                                                    return true;
                                                }
                                            }
                                            punten.Add(nieuwpunt);
                                            return true;
                                        }
                                    }
                                    punten.Add(nieuwpunt);
                                    return true;
                                }
                            }
                            punten.Add(nieuwpunt);
                            return true;
                        }
                    }
                    punten.Add(nieuwpunt);
                    return true;
                }
            }
            punten.Add(nieuwpunt);
            return true;
        }
    }

    [XmlRoot("SelectiePunt")]
    public class SelectiePunt
    {
        CultureInfo provider = CultureInfo.InvariantCulture;

        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlArray("Selectiepunten"), XmlArrayItem("SelectiePunt")]
            public List<SelectiePunt> Selectiepunten { get; set; }

        [XmlElement("Basisindeling")]
            public string Basisindeling { get; set; }
        [XmlElement("Domein")]
            public string Domein { get; set; }
        [XmlElement("Taak")]
            public string Taak { get; set; }
        [XmlElement("Handeling")]
            public string Handeling { get; set; }
        [XmlElement("Document")]
            public string Document { get; set; }

        [XmlElement("Volgnummer")]
            public string Volgnummer { get; set; }
        [XmlElement("Niveaunaam")]
            public string Niveaunaam { get; set; }
        [XmlElement("Omschrijving")]
            public string Omschrijving { get; set; }
        [XmlElement("Identificatie")]
            public string Identificatie { get; set; }

        [XmlElement("Bestemming")]
            public string Bestemming { get; set; }
        [XmlElement("Selectievoorwaarden")]
            public string Selectievoorwaarden { get; set; }
        [XmlElement("Vernietigingstermijn")]
            public string Vernietigingstermijn { get; set; }

        [XmlElement("Toelichting")]
            public string Toelichting { get; set; }
        [XmlElement("Publicatie")]
            public string Publicatie { get; set; }
        [XmlElement("Gewijzigd")]
            public string Gewijzigd { get; set; }
        [XmlElement("Status")]
            public string Status { get; set; }
        [XmlElement("Federaal")]
            public string Federaal { get; set; }

        public bool Import(string[] punt)
        {
            if (punt.Length == 19 || punt.Length == 18)
            {
                Basisindeling = punt[0].Substring(0, 1);
                Domein = punt[1].Substring(0, 2);
                Taak = punt[2].Substring(0, 2);
                Handeling = punt[3].Substring(0, 2);
                id = punt[4] + punt[5].Substring(0, 2);
                Document = punt[5];

                Volgnummer = punt[6];
                Niveaunaam = punt[7];
                Omschrijving = punt[8];
                Identificatie = punt[9];

                Bestemming = punt[10];
                Selectievoorwaarden = punt[11];
                Vernietigingstermijn = punt[12];
                Toelichting = punt[13];
                Publicatie = punt[14];
                Gewijzigd = punt[15];
                Status = punt[16];
                Federaal = punt[17];

                return true;
            }
            return false;
        }
        public SelectiePunt()
        {
            Selectiepunten = new List<SelectiePunt>();
        }

    }
}
