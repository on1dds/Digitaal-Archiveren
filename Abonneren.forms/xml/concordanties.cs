using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.DirectoryServices.AccountManagement;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Concorderen
{
    public class Abonnementen
    {
        public Concordanties Concordanties = new Concordanties();

        public void ReadDiensten()
        {
            // haal alle diensten uit XML bestand
            ImportXml("abonnementen.xml");

            // importeer alle diensten die nog niet bestaan uit de Active Directory
            List<String> ad = ImportAD();
            foreach(String dienstnaam in ad)
            {
                if (inDiensten(dienstnaam) == false)
                {
                    Dienst dienst = new Dienst();
                    dienst.id = dienstnaam;
                    Concordanties.Diensten.Add(dienst);
                }
            }

            // tag alle tags
            foreach(Dienst d in Concordanties.Diensten)
            {
                d.Root = Concordanties;
                TagMappen(d.Mappen, d, null);
            }
        }

        public void TagMappen(List<Map> mappen, Dienst root, Map parent)
        {
            foreach (Map map in mappen)
            {
                map.Dienst = root;
                map.Parent = parent;
                if (map.Mappen.Count > 0)
                {
                    TagMappen(map.Mappen, root, map);
                }
            }
        }

        public Dienst GetDienst(string s)
        {
            foreach(Dienst d in Concordanties.Diensten)
                if (s == d.id) return d;
            return null;
        }

        public bool inDiensten(string s)
        {
            foreach(Dienst d in Concordanties.Diensten)
                if (d.id == s) return true;

            return false;
        }

        public void WriteDiensten()
        {
            ExportXml("abonnementen.xml");
        }

        public void ImportXml(string fn)
        {
            if (File.Exists(fn))
            {
                TextReader xmlReader;
                XmlSerializer xmlSerial;

                xmlReader = new StreamReader(fn);
                xmlSerial = new XmlSerializer(typeof(Concordanties));

                Concordanties = (Concordanties)xmlSerial.Deserialize(xmlReader);

                xmlReader.Close();
            }
        }

        public void ExportXml(string fn)
        {
            // verwijder diensten zonder concordanties
            Dienst d = new Dienst();
            for(int i = 0;i< Concordanties.Diensten.Count;i++)
            {
                d = Concordanties.Diensten[i];
                if (Concordanties.Diensten[i].Mappen.Count == 0)
                {
                    i--;
                    Concordanties.Diensten.Remove(d);
                }
            }

            // schrijf XML naar bestand
            TextWriter xmlWriter;
            XmlSerializer xmlSerial;

            xmlWriter = new StreamWriter(fn);
            xmlSerial = new XmlSerializer(typeof(Concordanties));
            xmlSerial.Serialize(xmlWriter, Concordanties);
            xmlWriter.Close();
        }

        public List<String> ImportAD()
        {
            List<String> lijst = new List<String>();
            // create your domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            GroupPrincipal qbeGroup = new GroupPrincipal(ctx);
            PrincipalSearcher srch = new PrincipalSearcher(qbeGroup);

            foreach (var found in srch.FindAll())
            {
                Principal p = (Principal)found;
                string naam = p.Name;
                if (naam.Length > 7 && naam.Substring(0, 7) == "dienst_")
                    lijst.Add(naam.Substring(7));
            }
            return lijst;
        }

        public void BuildDiensten()
        {
            if (Concordanties.Diensten.Count == 0)
            {
                for (int i = 1; i <= 5; i++)
                {
                    Dienst d = new Dienst();
                    d.id = "dienst" + i.ToString();
                    Concordanties.Diensten.Add(d);
                }
            }
        }
    }

    [XmlRoot("Concordanties")]
    public class Concordanties
    {
        [XmlArray("Diensten",IsNullable = true), XmlArrayItem("Dienst")]
        public List<Dienst> Diensten;

        public Concordanties()
        {
            Diensten = new List<Dienst>();
        }
    }

    [XmlRoot("Dienst")]
    public class Dienst
    {
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlArray("Mappen", IsNullable = true), XmlArrayItem("Map")]
        public List<Map> Mappen;

        [XmlIgnore]
        public Concordanties Root;
        
        public Dienst()
        {
            Mappen = new List<Map>();
        }

        override public string ToString()
        {
            return id;
        }

        public void Addmap(Map map)
        {
            map.Dienst = this;
        }

    }

    [XmlRoot("Map")]
    public class Map
    {
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlElement("SelectiepuntID")]
        public string SelectiepuntID { get; set; }

        [XmlArray("Mappen"), XmlArrayItem("Map")]
        public List<Map> Mappen;

        [XmlIgnore]
        public Dienst Dienst;

        [XmlIgnore]
        public Map Parent;

        public Map()
        {
            Mappen = new List<Map>();
            Dienst = new Dienst();
        }

        public void Add(Map map)
        {
            map.Dienst = this.Dienst;
            map.Parent = this;
            Mappen.Add(map);
        }

        override public string ToString()
        {
            return id;
        }
    }

    #region code


    #endregion

    //private PrincipalContext GetDomain()
    //{
    //    try
    //    {
    //        return new PrincipalContext(ContextType.Domain);
    //    }
    //    catch
    //    {
    //        return null;
    //    }
    //}
}

