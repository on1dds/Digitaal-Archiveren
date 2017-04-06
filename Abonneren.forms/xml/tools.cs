using System.Xml.Serialization;
using System.IO;

namespace Abonneren.forms
{
    public static class Tools
    {
        static public SelectieLijst ReadSelectielijst(string fn)
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



        static public AbonnementenLijst ReadAbonnementen(string fn)
        {

            AbonnementenLijst lijst = new AbonnementenLijst();
            if (File.Exists(fn))
            {
                TextReader xmlReader;
                XmlSerializer xmlSerial;

                xmlReader = new StreamReader(fn);
                xmlSerial = new XmlSerializer(typeof(AbonnementenLijst));
                lijst = (AbonnementenLijst)xmlSerial.Deserialize(xmlReader);
                xmlReader.Close();
            }
            return lijst;
        }

        static public void WriteAbonnementen(string fn,AbonnementenLijst abonnementenlijst)
        {
            TextWriter xmlWriter;
            XmlSerializer xmlSerial;

            xmlWriter = new StreamWriter(fn);
            xmlSerial = new XmlSerializer(typeof(AbonnementenLijst));
            xmlSerial.Serialize(xmlWriter, abonnementenlijst);
            xmlWriter.Close();
        }

    }
}
